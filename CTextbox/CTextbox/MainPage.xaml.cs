using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CTextbox
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

        private async void Loadtxt1_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/temp.txt"));
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            DataReader reader = DataReader.FromBuffer(buffer);
            byte[] fileContent = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(fileContent);
            string fileText = Encoding.UTF8.GetString(fileContent, 0, fileContent.Length);
            txtShow.Text = fileText;
        }

        private async void Loadtxt2_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/temp.txt"));
            string fileText = await FileIO.ReadTextAsync(file);
            txtShow.Text = fileText;
        }

        public class NullableValueConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                return string.IsNullOrEmpty(value.ToString()) ? null : value;
            }
        }
    }
}
