using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Calls;
using Windows.Phone.Media.Devices;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CShowUINull
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private FeedItem selectedItem;
        private string test;
        AudioRoutingEndpoint current = AudioRoutingManager.GetDefault().GetAudioEndpoint();
        public MainPage()
        {
            this.InitializeComponent();
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += OnDataRequested;
        }

        private void ShowSharebutton_Click(object sender, RoutedEventArgs e)

        { var button = (Button)sender;
            selectedItem = (FeedItem)button.DataContext;
            test = "MyTest";
            DataTransferManager.ShowShareUI();

        }
         
        /// <summary>
        ///     Required by system, formats the output string to:
        ///         "My new article headline > http://myblog.tld/myFoo"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
           // if (selectedItem == null) return; // is always null as well the dummy test variable
            if (test == null) return;
            DataRequest request = args.Request;
            request.Data.SetText(string.Format("{0} > {1}", selectedItem.Title, selectedItem.Link));
        }

        private void ShowcallUI_Click(object sender, RoutedEventArgs e)
        {
            //PhoneCallManager
            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI("123456", "test");
        }

     
            //if (current.ToString() == "WiredHeadset")
            //{

            //   ////////////////////////////

            //}
    }
}
