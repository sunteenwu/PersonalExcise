using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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

namespace StorageFile2
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

        private async void SaveToAsserts_Click(object sender, RoutedEventArgs e)
        {

            string js = "I'm the json file";
            //StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            string path1 = Package.Current.InstalledLocation.Path;
            System.Diagnostics.Debug.WriteLine(Package.Current.InstalledLocation.Path);
            StorageFolder Assets = await Package.Current.InstalledLocation.GetFolderAsync("Assets");
            System.Diagnostics.Debug.WriteLine(Assets.Path);
            //StorageFile testfile = await StorageFile.CreateStreamedFileFromUriAsync("upcoming.Json",new Uri("ms-appx:///Assets"), js);
            StorageFile textFile = await Assets.CreateFileAsync("upcoming.Json", CreationCollisionOption.ReplaceExisting);
            //StorageFolder Assets2 = await StorageFolder.GetFolderFromPathAsync("");
            using (IRandomAccessStream textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (DataWriter textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(js);
                    await textWriter.StoreAsync();
                }
            }
        }

        private async void ReplaceLocal_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".bmp");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
                BitmapImage pic = new BitmapImage();
                pic.SetSource(stream);
                this.head.Source = pic;
                 head.imag
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await storageFolder.CreateFileAsync(PlayerName.Text + ".jpg", CreationCollisionOption.ReplaceExisting);
                await file.CopyAndReplaceAsync(sampleFile);
            }
        }
    }
}
