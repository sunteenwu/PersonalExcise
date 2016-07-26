using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CStorageFile
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

        private async void CreateFile_Click(object sender, RoutedEventArgs e)
        {

            var folderPicker = new FolderPicker();
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            if (folder != null)
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                var allFilesFolders = await folder.GetItemsAsync(); // exception is thrown
            }
            //StorageApplicationPermissions.FutureAccessList.Clear();
            //StorageFile file = await Windows.Storage.DownloadsFolder.CreateFileAsync("Json.json", CreationCollisionOption.GenerateUniqueName);
            //// var filepath =  file.Path;

            //string filepath = "C:\\Users\\Administrator\\Downloads\\29e3989d-f4ef-4e08-b2a7-ed2c6211d278_75cr2b68sm664!App\\Json (2).json";
            //StorageFile fileget = await StorageFile.GetFileFromPathAsync(filepath);

            //await fileget.DeleteAsync();

            //var listToken = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);
            //string listToken = "{F7D10357-CA60-441B-81A3-2949E233B32F}";
            //StorageItemAccessList chache = StorageApplicationPermissions.FutureAccessList;

            // var list = chache.Entries;
            //var file=await chache.GetFileAsync(listToken);
            // var test =  chache.CheckAccess(file);
            // chache.Remove(listToken);

            //file.DeleteAsync()
            // StorageFile file2=await StorageFile.GetFileFromPathAsync(KnownFolders.)
            // System.Diagnostics.Debug.WriteLine(DownloadsFolder.CreateFolderAsync(file.ToString());
            // StorageFile file = await Windows.Storage.DownloadsFolder.CreateFileAsync("39test.json", CreationCollisionOption.FailIfExists);

            //HttpClient client = new HttpClient();
            //await client.GetAsync(new Uri("http://baidu.com"));


        }

        private async void picture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StorageFile thumbnailFile = await Package.Current.InstalledLocation.GetFileAsync("Assets\\150.png");
                System.Diagnostics.Debug.WriteLine(Package.Current.InstalledLocation.Path);
                StorageFolder Assets = await Package.Current.InstalledLocation.GetFolderAsync("Assets");
                StorageFile textFile = await Assets.CreateFileAsync("upcoming.Json", CreationCollisionOption.ReplaceExisting);
                //txtpicpath.Text = thumbnailFile.Path;
                //txtpicpath.Text += Assets.Path;
                txtpicpath.Text += textFile.Path;

            }
            catch (Exception ex)
            {
                new Windows.UI.Popups.MessageDialog(ex.ToString());
                txtpicpath.Text += "Something wrong:"+ Package.Current.InstalledLocation.Path;           
            }

        }

        private async void picture2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageFile thumbnailFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/150.png"));
                txtpicpath2.Text = thumbnailFile.Path;               
            }
            catch (Exception ex)
            {
                new Windows.UI.Popups.MessageDialog(ex.ToString());
            }

        }

        private async void Futurelist_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FolderPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add("*");

            StorageFolder result = await picker.PickSingleFolderAsync();
            if (result != null)
            {
                string token = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(result);

                StorageFile tokenfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/FileToken.txt"));
                await FileIO.WriteTextAsync(tokenfile, token);

                // save the token
            }
        }

        private async void getfolder_Click(object sender, RoutedEventArgs e)
        {
      // StorageFile tokenfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/FileToken.txt"));
        //    string token = await FileIO.ReadTextAsync(tokenfile);
            string token = "{E5CB403B-D3A6-4F13-B538-123707BF1850}";
            StorageFolder tokenfolder = await StorageApplicationPermissions.FutureAccessList.GetFolderAsync(token);
            await new Windows.UI.Popups.MessageDialog(tokenfolder.Path.ToString()).ShowAsync();
            StorageItemAccessList chache = StorageApplicationPermissions.FutureAccessList;
            chache.CheckAccess(tokenfolder);
           //await new Windows.UI.Popups.MessageDialog(chache).ShowAsync();
        }

        private async void SaveToAsserts_Click(object sender, RoutedEventArgs e)
        {
            string js = "I'm the json file";
            //StorageFolder localFolder = ApplicationData.Current.LocalFolder;

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
    }
}
