using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CHttpClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string kl="test";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            var formData = new Dictionary<string, string>();
            formData.Add("kl", kl);

            var content = new FormUrlEncodedContent(formData);

            using (var httpClient = new HttpClient())
            {
                var httpRequest = await httpClient.PostAsync("http://placeholder.com/post/mailurl", content);
                var responseString = await httpRequest.Content.ReadAsStringAsync();

            }
        }
    }
}
