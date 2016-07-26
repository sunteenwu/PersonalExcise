using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CompuSight.Metro.Samples.HttpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CancellationTokenSource m_CancellationSource = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // When operations happen on a background thread we have to marshal UI updates back to the UI thread.
        private void MarshalLog(string value)
        {
            var ignore = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Log(value));
        }

        private void Log(string message)
        {
            OutputField.Text += message + "\r\n";
        }

        private async void StartDownloadClick(object sender, RoutedEventArgs e)
        {
            string resourceAddress = Address.Text.Trim();

            try
            {
                // We declare our progress callback action
                Action<int> reportProgress = (progresss) =>
                {
                    Debug.WriteLine("\t{0:o}\tCurrent Progress {1} bytes", DateTime.Now, progresss);
                    MarshalLog(string.Format("Current Progress {0} bytes", progresss));
                };

                //                     

                var client = new System.Net.Http.HttpClient();

                // We prepare the HttpRequest to be sent
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, resourceAddress);

                m_CancellationSource = new CancellationTokenSource();

                // Get the token from the cancellation source
                var token = m_CancellationSource.Token;

                var operationWithProgress = client.GetStringAsyncWithProgress(request, token);

                // We assign the progress action we defined
                operationWithProgress.Progress = (result, progress) => reportProgress(progress);

                // You can as well set a Timeout value
                //m_CancellationSource.CancelAfter(2000);

                var response = await operationWithProgress;

                MarshalLog("COMPLETED \r\n");
            }
            catch (HttpRequestException hre)
            {
                MarshalLog("ERROR \r\n");
                MarshalLog("HttpRequestException: " + hre.ToString());
            }
            catch (OperationCanceledException ex)
            {
                MarshalLog("CANCELLED \r\n");
                MarshalLog("OperationCancelledException: " + ex.ToString());
            }
            catch (Exception ex)
            {
                MarshalLog("ERROR \r\n");
                MarshalLog("Exception: " + ex.ToString());
            }
        }

        private void CancelDownloadClick(object sender, RoutedEventArgs e)
        {
            if (m_CancellationSource != null) m_CancellationSource.Cancel();

            m_CancellationSource = null;
        }
    }
}
