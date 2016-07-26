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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CDynamicStack
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
        private void DeviceLine_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as StackPanel).IsTapEnabled = true;
            (sender as StackPanel).PointerPressed += DeviceLine_PointerPressed;

        }
        private void DeviceLine_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            
            //System.Diagnostics.Debug.WriteLine(e.GetCurrentPoint(StackPanel)           
            VisualStateManager.GoToState(this, "DeviceSelected", false);
        }
    }
}
