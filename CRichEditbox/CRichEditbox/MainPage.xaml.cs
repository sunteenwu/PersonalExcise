using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CRichEditbox
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

        private void BtnRichedit_Click(object sender, RoutedEventArgs e)
        {
            Richbox.Document.Selection.CharacterFormat.ForegroundColor = Colors.Red;
            Richbox.Document.Selection.CharacterFormat.Bold = FormatEffect.On;
        }

        private async void Loadfile_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync("test1.rtf");

            IRandomAccessStream randAccStream = await file.OpenAsync(FileAccessMode.Read);
            Richbox.Document.LoadFromStream(TextSetOptions.FormatRtf, randAccStream);
        }


        private async void BtnGetformat_Click(object sender, RoutedEventArgs e)
        {
            string text = "inihital";
            Richbox.Document.GetText(TextGetOptions.FormatRtf, out text);
            await new Windows.UI.Popups.MessageDialog(text).ShowAsync();
        }
    }
}
