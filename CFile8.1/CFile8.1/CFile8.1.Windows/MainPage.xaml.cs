using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace CFile8._1
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

        private async void WriteFile_Click(object sender, RoutedEventArgs e)
        {       //var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures);
            //IObservableVector<Windows.Storage.StorageFolder> myPictureFolders = myPictures.Folders;
            //Windows.Storage.StorageFolder savePicturesFolder = myPictures.SaveFolder;

            List<string> stringlist = new List<string> { "I'm the string1", "I'm the string2", "I'm the string3" };
            StorageFolder picfolder = KnownFolders.PicturesLibrary;
            StorageFile textlistfile = await picfolder.CreateFileAsync("textlistfile.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteLinesAsync(textlistfile, stringlist);
        }
    }
}
