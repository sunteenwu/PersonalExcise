using CuploadpictureClient;
using CuploadpictureClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CuploadpictureClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<PromotionList> PromoList { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            PromoList = new ObservableCollection<PromotionList>();
        }
        private void connectsql_Click(object sender, RoutedEventArgs e)
        {
            Service1Client client = new Service1Client();
            PromoList = client.GetPromotionListAsync().Result;
            Debug.WriteLine(PromoList[0]);
        }

        //public ObservableCollection<PromotionList> GetPromotionList()
        //{
        //    ObservableCollection<PromotionList> result = new ObservableCollection<PromotionList>();
        //    //Add data string here
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        conn.ConnectionString = //This one is ado one that copy from the azure
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        //Query Here
        //        String cmdText = "Select * from Promo";
        //        cmd.CommandText = cmdText;
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            result.Add(new PromotionList() { id = dr.GetInt32(0), PromoName = dr.GetString(1) });
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //        {
        //            conn.Close();
        //        }

        //    }
        //    return result;
        //}

        public async Task<ImageSource> SaveToImageSource(byte[] imageBuffer)
        {
            ImageSource imageSource = null;
            //using (MemoryStream stream = new MemoryStream(imageBuffer))
            //{
            //    var ras = stream.AsRandomAccessStream();
            //    BitmapImage bitimage = new BitmapImage();
            //    bitimage.SetSource(ras);
            //    imgshow.Source = bitimage;
            //}
            using (MemoryStream stream = new MemoryStream(imageBuffer))
            {
                var ras = stream.AsRandomAccessStream();
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(BitmapDecoder.JpegDecoderId, ras);
                var provider = await decoder.GetPixelDataAsync();
                byte[] buffer = provider.DetachPixelData();
                WriteableBitmap bitmap = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
                await bitmap.PixelBuffer.AsStream().WriteAsync(buffer, 0, buffer.Length);
                imageSource = bitmap;
            }
            return imageSource;
        }
        public async Task<byte[]> SaveToBytesAsync(ImageSource imageSource)
        {
            byte[] imageBuffer;
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync("temp.jpg", CreationCollisionOption.ReplaceExisting);
            using (var ras = await file.OpenAsync(FileAccessMode.ReadWrite, StorageOpenOptions.None))
            {
                WriteableBitmap bitmap = imageSource as WriteableBitmap;
                var stream = bitmap.PixelBuffer.AsStream();
                byte[] buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, ras);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight, 96.0, 96.0, buffer);
                await encoder.FlushAsync();

                var imageStream = ras.AsStream();
                imageStream.Seek(0, SeekOrigin.Begin);
                imageBuffer = new byte[imageStream.Length];
                var re = await imageStream.ReadAsync(imageBuffer, 0, imageBuffer.Length);

            }
            await file.DeleteAsync(StorageDeleteOption.Default);
            return imageBuffer;
        }
        public byte[] AsByteArray(WriteableBitmap bitmap)
        {
            using (Stream stream = bitmap.PixelBuffer.AsStream())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
        private async void Convert_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileOpenPicker.FileTypeFilter.Add(".jpg");
            fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;

            var inputFile = await fileOpenPicker.PickSingleFileAsync();

            if (inputFile == null)
            {
                // The user cancelled the picking operation
                return;
            }

            SoftwareBitmap softwareBitmap;
            using (IRandomAccessStream stream = await inputFile.OpenAsync(FileAccessMode.Read))
            {
                // Create the decoder from the stream
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);

                // Get the SoftwareBitmap representation of the file
                softwareBitmap = await decoder.GetSoftwareBitmapAsync();
            }
            //var bitmap = new SoftwareBitmap(BitmapPixelFormat.Bgra8, 200, 200);
            var bitmap = softwareBitmap;
            var imgSource = new WriteableBitmap(bitmap.PixelWidth, bitmap.PixelHeight);
            imgbit.Source = imgSource;
            //SaveToBytesAsync(imgSource);
            bitmap.CopyToBuffer(imgSource.PixelBuffer);
            var dataArrayTobeSent = AsByteArray(imgSource);
            //var dataArrayTobeSent=await SaveToBytesAsync(imgSource);

            // imgshow.Source = await SaveToImageSource(dataArrayTobeSent);
            using (MemoryStream stream = new MemoryStream(dataArrayTobeSent))
            {
                IRandomAccessStream ras = stream.AsRandomAccessStream();
                BitmapImage bitimage = new BitmapImage();
                await bitimage.SetSourceAsync(ras);
                imgshow.Source = bitimage;
            }
            try
            {
                //Create the StreamSocket and establish a connection to the echo server.
                Windows.Networking.Sockets.StreamSocket socket = new Windows.Networking.Sockets.StreamSocket();

                //The server hostname that we will be establishing a connection to. We will be running the server and client locally,
                //so we will use localhost as the hostname.
                Windows.Networking.HostName serverHost = new Windows.Networking.HostName("localhost");

                //Every protocol typically has a standard port number. For example HTTP is typically 80, FTP is 20 and 21, etc.
                //For the echo server/client application we will use a random port 1337.
                string serverPort = "1334";
                try
                {
                    await socket.ConnectAsync(serverHost, serverPort);
                    await new Windows.UI.Popups.MessageDialog("Connected").ShowAsync();
                }
                catch
                {
                    await new Windows.UI.Popups.MessageDialog("Connect fail").ShowAsync();
                }

                //Write data to the echo server.

                DataWriter writer = new DataWriter(socket.OutputStream);
                writer.WriteBytes(dataArrayTobeSent);
                await writer.StoreAsync();


                //Read data from the echo server.
                //Stream streamIn = socket.InputStream.AsStreamForRead();
                //StreamReader reader = new StreamReader(streamIn);
                //string response = await reader.ReadLineAsync();
            }
            catch (Exception ex)
            {
                await new Windows.UI.Popups.MessageDialog("Not to end").ShowAsync();
            }

            //using (TcpClient client = new TcpClient(host, port))
            //{
            //    using (NetworkStream stream = client.GetStream())
            //    {
            //        byte[] bytes = Encoding.UTF8.GetBytes(xxxxxxx);
            //        //send request
            //        stream.Write(bytes, 0, bytes.Length);

            //        //get response
            //        byte[] array = new byte[1024];
            //        int l = await stream.ReadAsync(array, 0, array.Length);
            //    }
            //}
        }

        private async void BtnResizeSave_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(ContentPanel);

            // saving as jpg
            var file = await KnownFolders.PicturesLibrary.CreateFileAsync("sample.png");
            using (var stream = await file.OpenStreamForWriteAsync())
            {
                var pixelBuffer = await bitmap.GetPixelsAsync();
                var logicalDpi = DisplayInformation.GetForCurrentView().LogicalDpi;

                // convert stream to IRandomAccessStream
                var randomAccessStream = stream.AsRandomAccessStream();

                // encoding & finish saving
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, randomAccessStream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)bitmap.PixelWidth,
                                     (uint)bitmap.PixelHeight, logicalDpi, logicalDpi, pixelBuffer.ToArray());

                await encoder.FlushAsync();


                MessageDialog m = new MessageDialog("Saved");
                await m.ShowAsync();
            }
        }

        private async void BtnGetDpi_Click(object sender, RoutedEventArgs e)
        {
            //BitmapSource bitsource =(BitmapSource)Image.Source;

            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/HelloWorld.png"));
            using (IRandomAccessStream stream = await file.OpenReadAsync())
            {                
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(BitmapDecoder.PngDecoderId, stream); 
                var DpiX = decoder.DpiX;
                var DpiY = decoder.DpiY;                 
            }
        }

    }
}
