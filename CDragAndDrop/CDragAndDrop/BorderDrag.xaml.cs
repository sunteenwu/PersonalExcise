using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CDragAndDrop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BorderDrag : Page
    {
        public BorderDrag()
        {
            this.InitializeComponent();
        }

        private void TextBlock_DragStarting(UIElement sender, DragStartingEventArgs args)
        {

        }

        private void cnvDrop_DragOver(object sender, DragEventArgs e)
        {
            var point = e.GetPosition(cnvDrop);
            Canvas.SetLeft(dragtext, (point.X));
            Canvas.SetTop(dragtext, (point.Y));
        }

        private void cnvDrop_Drop(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Move;
        }
    }
}
