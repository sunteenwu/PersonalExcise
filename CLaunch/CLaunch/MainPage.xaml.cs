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

namespace CLaunch
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
        public string Link { get; set; }
        private async void BtnLaunch_Click(object sender, RoutedEventArgs e)
        {
            // Link = "http://wwww.baidu.com";
            ////var Linky = new Uri(@"{Binding Link}");
            // var Linky = new Uri(@"http://wwww.baidu.com");
            // var promptOptions = new Windows.System.LauncherOptions();
            // promptOptions.TreatAsUntrusted =true;
            // var success = await Windows.System.Launcher.LaunchUriAsync(Linky, promptOptions);
            // if (success)
            // {
            //     string test = "11";
            //     // URI launched
            // }
            // else
            // {
            //     // URI launch failed
            // }
            var success = await Windows.System.Launcher.LaunchUriAsync(new Uri(@"ms-clock://"));
            //var uri = new Uri("sun-targetapp://");
            //var options = new Windows.System.LauncherOptions();
            //options.TreatAsUntrusted = true;

            //var success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
        }

    }
}
 
