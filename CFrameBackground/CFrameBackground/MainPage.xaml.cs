using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CFrameBackground
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

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFile inputFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/caffe.jpg"));
            WriteableBitmap writeableBitmap = new WriteableBitmap(100, 200);
            ///Method1, Using WriteableBitmap
            if (inputFile != null)
            {
                using (IRandomAccessStream fileStream = await inputFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    try
                    {
                        await writeableBitmap.SetSourceAsync(fileStream);
                    }
                    catch (TaskCanceledException)
                    {
                        // The async action to set the WriteableBitmap's source may be canceled if the user clicks the button repeatedly
                    }
                }
 
            }
            ImageBrush b = new ImageBrush();
            b.ImageSource = writeableBitmap;
            b.Stretch = Stretch.UniformToFill;
            (Window.Current.Content as Frame).Background = b;
        }

        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(Pagetwo));
        }
    }
}
