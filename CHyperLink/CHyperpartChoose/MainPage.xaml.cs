using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CHyperpartChoose
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

        private void BtnSetHyperlink_Click(object sender, RoutedEventArgs e)
        {
            

            //HyperLinkedTextBlock.SetText(myTextBlock, “Gün geçmiyor ki teknoloji sitelerine bir yenisi eklenmesin.Mesela; http://www.teknomeknotekno.com, http://www.takinotekinotekno.net, Facebook sayfamsı şu sayfa http://www.facebook.com/teknotekinotakino, Youtube sayfamsı şu hesap http://www.youtube.com/teknotekinotakino ve Twitter hesabımsı bu sayfa http://www.twitter.com/teknotekinotakino bunlardan sadece bazıları :)”);
        }

        private async void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://msdn.microsoft.com/en-us/library"));
        }

        private async void TextBlock_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://msdn.microsoft.com/en-us/library"));
        }

        private async void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://msdn.microsoft.com/en-us/library"));
        }
    }
}
