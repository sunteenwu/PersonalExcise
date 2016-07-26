using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Writebuffer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private uint buffersize;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnWriteBuffer_Click(object sender, RoutedEventArgs e)
        {
            StorageFile sf =await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/caffe.jpg"));
            var writestream = await sf.OpenAsync(FileAccessMode.ReadWrite);
            var outputstream = writestream.GetOutputStreamAt(0);
            var datawriter = new DataWriter(outputstream);
            var buffer = new Windows.Storage.Streams.Buffer(buffersize);

            //save picker
            var saver = new Windows.Storage.Pickers.FileSavePicker();
            // saver.FileTypeChoices.Add("wav", new List<string>() { ".wav" });
            saver.FileTypeChoices.Add("jpg", new List<string>() { ".jpg" });
            var file = await saver.PickSaveFileAsync();
            //Windows.Storage.CachedFileManager.DeferUpdates(file);
            //await FileIO.WriteBufferAsync(file, buffer);
            //var status = await CachedFileManager.CompleteUpdatesAsync(file);



            //while (stream.Position < stream.Size)
            //{
            //    await stream.ReadAsync(buffer, buffersize, InputStreamOptions.None);
            //    datawriter.WriteBuffer(buffer);

            //    //custom code
            //    await FileIO.WriteBufferAsync(file, buffer);

            //}



            datawriter.StoreAsync().AsTask().Wait();

            outputstream.FlushAsync().AsTask().Wait();
            outputstream.Dispose();
            writestream.Dispose();
        }

        private async void BtnWriteBuffer2_Click(object sender, RoutedEventArgs e)
        {
            StorageFile sf = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/3.mp3"));
            IBuffer buffer = await FileIO.ReadBufferAsync(sf);    
            var saver = new Windows.Storage.Pickers.FileSavePicker();
            // saver.FileTypeChoices.Add("wav", new List<string>() { ".wav" });
            saver.FileTypeChoices.Add("mp3", new List<string>() { ".mp3" });
            var file = await saver.PickSaveFileAsync();
            using (IRandomAccessStream stream =await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                var outputstream = stream.GetOutputStreamAt(0);
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputstream))
                {
                    dataWriter.WriteBuffer(buffer);
                    await dataWriter.StoreAsync();
                    await outputstream.FlushAsync();
                }              
            }        
           

        }
    }
}
