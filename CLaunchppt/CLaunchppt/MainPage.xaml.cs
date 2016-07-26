using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CLaunchppt
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

        private async void Btnlaunchppt_Click(object sender, RoutedEventArgs e)
        {
            string filepath =@"Assets\AppService.pptx";
            //string imageFile = @"Assets\StoreLogo.png";
            Debug.WriteLine(Windows.ApplicationModel.Package.Current.InstalledLocation.ToString());
            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(filepath);
            try
            {
                var options = new Windows.System.LauncherOptions();
                options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseHalf;
             //   var urii = new Uri(file.Path);
                await Windows.System.Launcher.LaunchFileAsync(file, options);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void BtnLaunchLinkIn_Click(object sender, RoutedEventArgs e)
        {
            //LauncherOptions option = new LauncherOptions();
            //option.TargetApplicationPackageFamilyName="12825MacleySousa.Applinkedin_1.1.54.0_x64__69zv3n63d894c";
            //// await  Launcher.LaunchUriAsync(new Uri("https://www.linkedin.com/in/%E8%AF%A2-%E5%90%B4-b868a9117"),option);
            //await Launcher.LaunchUriAsync(new Uri("linkedin://profile?id=b868a9117"));

        var sucess=  await Windows.System.Launcher.LaunchUriAsync(new Uri(@"ms-clock:"));
        }
    }
}
