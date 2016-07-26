using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CShareTarget
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ShareOperation shareOperation;
        public MainPage()
        {
            this.InitializeComponent();

        }

        protected override async void OnGotFocus(RoutedEventArgs e)
        {
            Uri uriReceived = null;
            if (shareOperation.Data.Contains(StandardDataFormats.WebLink))
                uriReceived = await shareOperation.Data.GetWebLinkAsync();
            this.shareOperation.ReportCompleted();
            base.OnGotFocus(e);
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.shareOperation = (ShareOperation)e.Parameter;
        }
        private void reportcomplete_Click(object sender, RoutedEventArgs e)
        {
            this.shareOperation.ReportCompleted();
        }

        private void bShareURL_Click(object sender, RoutedEventArgs ex)
        {
            DataTransferManager.GetForCurrentView().DataRequested += (s, e) =>
            {
                DataPackage dataPackage = e.Request.Data;
                dataPackage.Properties.Title = "Share";
                dataPackage.SetUri(new Uri("http://www.google.es"));
            };
            DataTransferManager.ShowShareUI();
        }
    }
}
