using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace CPivot
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PivotBinding : Page
    {
        public PivotBinding()
        {
            this.InitializeComponent();
            string visible = "Collapsed";
            this.DataContext = visible;
            imgdirection.RenderTransformOrigin = new Point { X = 0.5, Y = 0.5 };
            imgdirection.RenderTransform = new ScaleTransform() { ScaleY = -1 };
            imgdirection.UpdateLayout();
        }
    }
}
