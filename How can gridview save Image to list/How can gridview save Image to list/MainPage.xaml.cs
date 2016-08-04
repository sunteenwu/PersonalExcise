using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace How_can_gridview_save_Image_to_list
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private WriteableBitmap _writeableBitmap;
        private Image dddd;

        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker =
    new FileOpenPicker();
            openPicker.SuggestedStartLocation =
       Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            openPicker.ViewMode =
                Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            // Filter to include a sample subset of file types.
            openPicker.FileTypeFilter.Clear();
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".jpg");
            StorageFile file =
                await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Set the image source to the selected bitmap.
                    _writeableBitmap = new WriteableBitmap(1200, 778);
                    await _writeableBitmap.SetSourceAsync(fileStream);
                    dddd = new Image();
                    dddd.Source = _writeableBitmap;
                    gridv.Items.Add(dddd); 
                }
            }

        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            List<Image> imagelist = new List<Image>();
            foreach (var item in gridv.Items)
            {
                Image im = item as Image;
                //Image im = (item as GridViewItem).Content as Image;
                imagelist.Add(im);
            }
        }
    }
}
