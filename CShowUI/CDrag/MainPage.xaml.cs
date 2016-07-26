using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CDrag
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        RandomAccessStreamReference bitmap;
        BitmapImage bitmapimage;
        public MainPage()
        {
            this.InitializeComponent();

            if (imgDrag.Source != null)
            {
                bitmapimage = imgDrag.Source as BitmapImage;
            bitmap = RandomAccessStreamReference.CreateFromUri(bitmapimage.UriSource);
            }
        }

        private void imgDrag_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            ApplicationDataContainer localsettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localsettings.Values["test"] = imgDrag;

             //args.Data.SetBitmap(bitmap);
        }

        private  void cnvDrop_Drop(object sender, DragEventArgs e)
        {
            //RandomAccessStreamReference streamref = await e.DataView.GetBitmapAsync();
            //BitmapImage bitmapimage = new BitmapImage();
            //bitmapimage.SetSource(await streamref.OpenReadAsync());
            imgDrag.Source = bitmapimage;

            var point = e.GetPosition(cnvDrop);
            Canvas.SetLeft(imgDrag, (point.X));
            Canvas.SetTop(imgDrag, (point.Y));
        }

        private void cnvDrop_DragOver(object sender, DragEventArgs e)
        {
            imgDrag.Source = null;
            e.AcceptedOperation = DataPackageOperation.Move;
            e.DragUIOverride.IsCaptionVisible = false;
        }
    }
}
