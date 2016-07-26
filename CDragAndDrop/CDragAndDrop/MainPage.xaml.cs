using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CDragAndDrop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        BitmapImage bitmapimage;
        ObservableCollection<DragItem> _selection;
        public MainPage()
        {
            this.InitializeComponent();
            
            ObservableCollection<DragItem> dragitems = new ObservableCollection<DragItem>() {
            new DragItem { text="My Research Paper"},
            new DragItem { text="Electricity Bill"},
            new DragItem { text="Sunteen"}};
            SourceListView.ItemsSource = dragitems;
            TargetListView.ItemsSource = _selection;
        }

        //private void imgDrag_DragStarting(UIElement sender, DragStartingEventArgs args)
        //{
        //}

        //private void cnvDrop_Drop(object sender, DragEventArgs e)
        //{
        //    // imgDrag.Source = bitmapimage;

        //    var point = e.GetPosition(cnvDrop);
        //    Canvas.SetLeft(imgDrag, (point.X));
        //    Canvas.SetTop(imgDrag, (point.Y));
        //}

        //private void cnvDrop_DragOver(object sender, DragEventArgs e)
        //{
        //    //imgDrag.Source = null;
        //    e.AcceptedOperation = DataPackageOperation.Move;
        //    // e.DragUIOverride.IsCaptionVisible = false;
        //    // e.DragUIOverride.IsGlyphVisible = false;
        //}

        private void SourceListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {

            // List<ListViewItem> items = e.Items as List<ListViewItem>;
            //ListViewItem item = e.Items as ListViewItem;

            // Prepare a string with one dragged item per line
            var items = new StringBuilder();
            foreach (var item in e.Items)
            {
                var text = item as DragItem;

                if (items.Length > 0) items.AppendLine();
                items.Append(text.text);
            }
            // Set the content of the DataPackage
            e.Data.SetText(items.ToString());
            // As we want our Reference list to say intact, we only allow Copy
            e.Data.RequestedOperation = DataPackageOperation.Copy;
        }

        private void TargetListView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = (e.DataView.Contains(StandardDataFormats.Text)) ? DataPackageOperation.Copy : DataPackageOperation.None;
        }

        private async void TargetListView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                // We need to take a Deferral as we won't be able to confirm the end
                // of the operation synchronously
                var def = e.GetDeferral();
                var s = await e.DataView.GetTextAsync();
                var items = s.Split('\n');
                foreach (var item in items)
                {
                    _selection.Add(new DragItem { text=item} );
                }
                e.AcceptedOperation = DataPackageOperation.Copy;
                def.Complete();
            }
        }

        private void TargetListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {

        }

        private void TargetListView_DragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {

        }

        private void TextBlock_DragStarting(UIElement sender, DragStartingEventArgs args)
        {

        }
    }
    public class DragItem
    {
        public string text { get; set; }
    }

}
