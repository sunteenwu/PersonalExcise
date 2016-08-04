using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CWriteableBitmapEx
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            ChangeImageColor change = new ChangeImageColor();
            WriteableBitmap Bitmap = await change.downloadImageandChangeColor("http://i.stack.imgur.com/1cWvj.jpg", "blue");

            imgShow.Source = Bitmap;

        }
    }
    public class ChangeImageColor
    {
        public async Task<WriteableBitmap> downloadImageandChangeColor(string image_url, string hex_color)
        {
            Uri uri = new Uri(image_url);
            var fileName = getname(image_url);
            var bitmapImage = new BitmapImage();
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(uri);
            byte[] b = await httpResponse.Content.ReadAsByteArrayAsync();

            // create a new in memory stream and datawriter
            var stream = new InMemoryRandomAccessStream();

            DataWriter dw = new DataWriter(stream);

            // write the raw bytes and store
            dw.WriteBytes(b);
            await dw.StoreAsync();

            // set the image source
            stream.Seek(0);
            bitmapImage.SetSource(stream);



            // read from pictures library
            stream.Seek(0);
            WriteableBitmap bitMap = await GetFileFromStorageandChangeColor(fileName, stream, hex_color);

            //StorageFile file = await WriteableBitmapToStorageFile(bitMap, FileFormat.Png, fileName);

            return bitMap;
        }


        public async Task<WriteableBitmap> GetFileFromStorageandChangeColor(string fileName, InMemoryRandomAccessStream pictureStream, string hex_color)
        {
            //var pictureFile = await KnownFolders.PicturesLibrary.GetFileAsync(fileName);
            WriteableBitmap writeableBitmap = null;
            //using (var pictureStream = await pictureFile.OpenAsync(FileAccessMode.Read))
            //{
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(pictureStream);
            // Load the picture in a WriteableBitmap
            writeableBitmap = new WriteableBitmap(bmp.PixelWidth, bmp.PixelHeight);
            pictureStream.Seek(0);
            writeableBitmap.SetSource(pictureStream);

            // Now we have to extract the pixels from the writeablebitmap
            // Get all pixel colors from the buffer
            byte[] pixelColors = writeableBitmap.PixelBuffer.ToArray();

            // Execute the filter on the color array
            //ApplyFilter(pixelColors);
            writeableBitmap = ChangeColor(writeableBitmap, hex_color);

            // Tell the image it needs a redraw
            writeableBitmap.Invalidate();
            // }
            return writeableBitmap;
        }

        public WriteableBitmap ChangeColor(WriteableBitmap scrBitmap, string hex_value)
        {
            //You can change your new colour here.
            //Color newColor = MCSExtensions.GetColorFromHex(hex_value).Color;
            Color newColor = Colors.Blue;
            Color actualColor;

            //WriteableBitmap newBitmap = BitmapFactory.New(scrBitmap.PixelWidth, scrBitmap.PixelHeight);
            //newBitmap.ForEach((x, y, srcColor) => srcColor.A > 150 ? newColor : srcColor);
            //newBitmap.Invalidate();
            //make an empty bitmap the same size as scrBitmap
            WriteableBitmap newBitmap = new WriteableBitmap(scrBitmap.PixelWidth, scrBitmap.PixelHeight);

            var begintime = System.DateTime.Now;
            System.Diagnostics.Debug.WriteLine("BeginTime" + begintime);
            using (newBitmap.GetBitmapContext())
            {
                for (int i = 0; i < scrBitmap.PixelWidth; i++)
                {
                    for (int j = 0; j < scrBitmap.PixelHeight; j++)
                    {

                        actualColor = scrBitmap.GetPixel(i, j);
                        // > 150 because.. Images edges can be of low pixel colr. if we set all pixel color to new then there will be no smoothness left.
                        if (actualColor.A > 0)
                            newBitmap.SetPixel(i, j, (Color)newColor);
                        else
                            newBitmap.SetPixel(i, j, actualColor);

                        //get the pixel from the scrBitmap image             
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("I'm completed");
            var endtime = System.DateTime.Now;
            System.Diagnostics.Debug.WriteLine("endTime" + endtime);
            return newBitmap;

        }

        private async Task<StorageFile> WriteableBitmapToStorageFile(WriteableBitmap WB, FileFormat fileFormat, string fileName)
        {
            string FileName = fileName.Replace(".png", "") + ".";
            Guid BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
            switch (fileFormat)
            {
                case FileFormat.Jpeg:
                    FileName += "jpeg";
                    BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
                    break;
                case FileFormat.Png:
                    FileName += "png";
                    BitmapEncoderGuid = BitmapEncoder.PngEncoderId;
                    break;
                case FileFormat.Bmp:
                    FileName += "bmp";
                    BitmapEncoderGuid = BitmapEncoder.BmpEncoderId;
                    break;
                case FileFormat.Tiff:
                    FileName += "tiff";
                    BitmapEncoderGuid = BitmapEncoder.TiffEncoderId;
                    break;
                case FileFormat.Gif:
                    FileName += "gif";
                    BitmapEncoderGuid = BitmapEncoder.GifEncoderId;
                    break;
            }
            var file = await KnownFolders.PicturesLibrary.CreateFileAsync(
                        FileName,
                        CreationCollisionOption.ReplaceExisting);
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoderGuid, stream);
                Stream pixelStream = WB.PixelBuffer.AsStream();
                byte[] pixels = new byte[pixelStream.Length];
                await pixelStream.ReadAsync(pixels, 0, pixels.Length);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight,
                          (uint)WB.PixelWidth,
                          (uint)WB.PixelHeight,
                          96.0,
                          96.0,
                          pixels);
                await encoder.FlushAsync();
            }
            return file;
        }
        private enum FileFormat
        {
            Jpeg,
            Png,
            Bmp,
            Tiff,
            Gif
        }

        public static string getname(string name)
        {
            string image_name = string.Empty;
            image_name = (name).Substring(Math.Max(0, (name).Length - 20)).Replace(@"/", "_");
            return image_name;
        }
    }
}
