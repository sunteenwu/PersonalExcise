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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CCustomControl
{
    public sealed partial class PhotoView : UserControl
    {
        public PhotoView()
        {
            this.InitializeComponent();
        }

        private async void Viewbox_OnManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            await new Windows.UI.Popups.MessageDialog("OnMainipulationStart").ShowAsync();
        }

        private async void Viewbox_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            await new Windows.UI.Popups.MessageDialog("MaipulationDelta").ShowAsync();

            //if (IsAtMinZoom && e.Delta.Scale <= 1)
            //{
            //    e.Handled = false;
            //}
            //else {
            //    e.Handled = true;
            //    return;
            //}
        }
    }
}
