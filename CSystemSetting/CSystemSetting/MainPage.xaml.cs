using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CSystemSetting
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StorageFile downloadedFile;
        public MainPage()
        {
            this.InitializeComponent();
        }


        public static byte[] ReadStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        async private void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (downloadedFile != null)
            {
                await Windows.System.Launcher.LaunchFileAsync(downloadedFile);
            }
        }

        private async void ButtonDownload_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(TextBoxLink.Text))
            {
                FileSavePicker fileSavePicker = new FileSavePicker();
                fileSavePicker.SuggestedStartLocation = PickerLocationId.Downloads;
                fileSavePicker.FileTypeChoices.Add("Mp3", new List<string>() { ".mp3" });
                StorageFile file = await fileSavePicker.PickSaveFileAsync();
                if (file != null)
                {
                    try
                    {
                        ButtonDownload.IsEnabled = false;
                        ProgressBar.IsIndeterminate = true;
                        ProgressBar.Visibility = Visibility.Visible;
                        Uri address = new Uri(TextBoxLink.Text, UriKind.Absolute);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                        WebResponse response = await request.GetResponseAsync();
                        Stream stream = response.GetResponseStream();
                        await FileIO.WriteBytesAsync(file, ReadStream(stream));
                        downloadedFile = file;
                        ButtonDownload.IsEnabled = true;
                        ProgressBar.Visibility = Visibility.Collapsed;
                        ProgressBar.IsIndeterminate = false;
                        TextBlockDownloadComplete.Visibility = Visibility.Visible;
                        ButtonOpenFile.Visibility = Visibility.Visible;
                    }
                    catch (Exception ex)
                    {
                        MessageDialog messageDialog = new MessageDialog(ex.Message);
                        await messageDialog.ShowAsync();
                        ButtonDownload.IsEnabled = true;
                        ProgressBar.Visibility = Visibility.Collapsed;
                        ProgressBar.IsIndeterminate = false;
                        TextBlockDownloadComplete.Visibility = Visibility.Collapsed;
                        ButtonOpenFile.Visibility = Visibility.Collapsed;
                        downloadedFile = null;
                    }
                }
            }
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        { 
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/DevelopersGuidetoWin10ApptoApp.mp3"));
            var filebuffer=await FileIO.ReadBufferAsync(file);
            FileSavePicker fileSavePicker = new FileSavePicker();
            fileSavePicker.SuggestedFileName = "DevelopersGuidetoWin10ApptoApp";
            fileSavePicker.FileTypeChoices.Add("Mp3", new List<string>() { ".mp3" });
            StorageFile filetarget = await fileSavePicker.PickSaveFileAsync();
            if (filetarget != null)
            {
              await FileIO.WriteBufferAsync(filetarget, filebuffer);
            }       
        }
    }
}
