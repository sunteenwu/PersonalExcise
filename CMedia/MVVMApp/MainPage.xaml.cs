using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MVVMApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public OrganizationViewModel Organization { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            Organization = new OrganizationViewModel("Office");
        }

        //private CaptureElement _captureElement;
        //public CaptureElement CaptureElement
        //{
        //    get
        //    {
        //        return _captureElement;
        //    }

        //    set
        //    {
        //        _captureElement = value; OnChange("CaptureElement");
        //    }
        //}

        private  async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Using Windows.Media.Capture.MediaCapture APIs 
            // to stream from webcam
            MediaCapture mediaCaptureMgr = new MediaCapture();
            await mediaCaptureMgr.InitializeAsync();

            // Start capture preview.                
            myCaptureElement.Source = mediaCaptureMgr;
            await mediaCaptureMgr.StartPreviewAsync();
        }
    }
}
