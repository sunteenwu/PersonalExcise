using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CDownloadHttp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string server = "https://sec.ch9.ms/slides/developerGuideToWindows10/02-XAMLcontrols.pptx";
        string filename = "output.pptx";
        private HttpClient httpclient;
        private CancellationTokenSource cts;
        public MainPage()
        {
            this.InitializeComponent();
            httpclient = new HttpClient();
            cts = new CancellationTokenSource();
        }

        private async void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            var path = new Uri(server);

            using (var inputStream = (await httpClient.GetInputStreamAsync(path).AsTask(new MyProgress())).AsStreamForRead())
            {
                var outputFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                using (var outputStream = (await outputFile.OpenAsync(FileAccessMode.ReadWrite)).AsStreamForWrite())
                {
                    await inputStream.CopyToAsync(outputStream);

                    await outputStream.FlushAsync();
                }
            }

            Debug.WriteLine("done");
        }
        private class MyProgress : IProgress<HttpProgress>
        {
            public void Report(HttpProgress value)
            {
                Debug.WriteLine("HTTP {0} progress {1}/{2}", value.Stage, value.BytesReceived, value.TotalBytesToReceive);
            }
        }

        private async void BtnDownloadOther_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            var path = new Uri("https://sec.ch9.ms/slides/developerGuideToWindows10/02-XAMLcontrols.pptx");
            HttpResponseMessage response = await httpClient.GetAsync(path).AsTask(new MyProgress());
            using (Stream responseStream = (await response.Content.ReadAsInputStreamAsync()).AsStreamForRead())
            {
                var outputFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("output.pptx", CreationCollisionOption.ReplaceExisting);
                using (var outputStream = (await outputFile.OpenAsync(FileAccessMode.ReadWrite)).AsStreamForWrite())
                {
                    await responseStream.CopyToAsync(outputStream);
                    await outputStream.FlushAsync();
                }
            }
            Debug.WriteLine("done");
        }

        private void ProgressHandler(HttpProgress progress)
        {
            Debug.WriteLine("http {0} progress{1}/{2}", progress.Stage, progress.BytesReceived, progress.TotalBytesToReceive);
        }

        private async void GetStream_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            var path = new Uri(server);

            var inputStream = (await httpClient.GetBufferAsync(path).AsTask(new MyProgress()));

            var outputFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("output.mov", CreationCollisionOption.ReplaceExisting);

            using (var outputStream = (await outputFile.OpenAsync(FileAccessMode.ReadWrite)).AsStreamForWrite())
            {
                // await inputStream.CopyToAsync(outputStream);

                await outputStream.FlushAsync();
            }


            Debug.WriteLine("done");
        }

        private async void Listening_Click(object sender, RoutedEventArgs e)
        {

            var httpClient = new HttpClient();
            var path = new Uri(@"https://github.com/Microsoft/Windows-universal-samples/archive/master.zip");

            var inputStream = (await httpClient.GetStringAsync(path).AsTask(new MyProgress()));

            var outputFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("output.mov", CreationCollisionOption.ReplaceExisting);

            using (var outputStream = (await outputFile.OpenAsync(FileAccessMode.ReadWrite)).AsStreamForWrite())
            {
                // await inputStream.CopyToAsync(outputStream);

                await outputStream.FlushAsync();
            }


            Debug.WriteLine("done");
        }
    }
}
