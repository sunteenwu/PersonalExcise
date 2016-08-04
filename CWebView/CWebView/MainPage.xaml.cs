using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CWebView
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

        private void cachetest_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://www.baidu.com";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
           // request.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            //request.Headers.Add("Pragma", "no-cache");
             cweb.NavigateWithHttpRequestMessage(request);
            //var cachemode = cweb.CacheMode;
            //System.Diagnostics.Debug.WriteLine(cachemode);

            //Windows.Web.Http.Filters.HttpBaseProtocolFilter myFilter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
            //myFilter.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;
            //myFilter.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.Default;
        }

        private async void cachetest2_Click(object sender, RoutedEventArgs e)
        {
            //string url = "http://baike.baidu.com/link?url=eF6fd5r4XDcHSaf8ro6Tdbb9ecxoUjDDFf4f_ux2PtMISIqbo9DIaOIpXFpGXU_wvb-0-g2zLmpDGAnw59DnCK";
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            //request.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            //request.Headers.Add("Pragma", "no-cache");
            //cweb.NavigateWithHttpRequestMessage(request);
            await  WebView.ClearTemporaryWebDataAsync();
        }
    }
}
