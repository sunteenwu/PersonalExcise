using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CWebview
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

      

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            StorageFile f = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/html_example2.html"));
 
            HtmlBox.Text = await  FileIO.ReadTextAsync(f); 
        }

        private void LoadHtml_Click(object sender, RoutedEventArgs e)
        {
            WebViewControl.NavigateToString(HtmlBox.Text);
          
        }
    }
}
