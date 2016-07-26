using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CScreenSize
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
 
            //var size = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);
        }
        void detectScreenType()
        {
            double dpi = DisplayProperties.LogicalDpi;
            var bounds = Window.Current.Bounds;
            double h;
            switch (ApplicationView.Value)
            {
                case ApplicationViewState.Filled:
                    h = bounds.Height;
                    break;

                case ApplicationViewState.FullScreenLandscape:
                    h = bounds.Height;
                    break;

                case ApplicationViewState.Snapped:
                    h = bounds.Height;
                    break;

                case ApplicationViewState.FullScreenPortrait:
                    h = bounds.Width;
                    break;

                default:
                    return;
            }
            double inches = h / dpi;
            string screenType = "Slate";
            if (inches < 10)
            {
                screenType = "Slate";
            }
            else if (inches < 14)
            {
                screenType = "WorkHorsePC";
            }
            else
            {
                screenType = "FamilyHub";
            }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["screenType"] = screenType;
        }

        private void BtnDeviceBound_Click(object sender, RoutedEventArgs e)
        {
            var scaleFactor = DisplayInformation.GetForCurrentView().ResolutionScale;
            var x = DisplayInformation.GetForCurrentView().RawDpiX;
            var y = DisplayInformation.GetForCurrentView().RawDpiY;
            var n = DisplayInformation.GetForCurrentView().LogicalDpi;            
            var bounds = Window.Current.Bounds;
            double height = bounds.Height;
            double width = bounds.Width;

            result.Text += "  DisplayInformation.GetForCurrentView().RawDpiX:" + x;
            result.Text += "  DisplayInformation.GetForCurrentView().RawDpiY:" + y;
            result.Text += "  bounds.Height:" +height;
            result.Text += "  bounds.Width:" + width;
            result.Text += "  Currentall:" + n;
        }
    }
}
