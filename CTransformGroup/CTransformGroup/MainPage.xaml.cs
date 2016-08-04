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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CTransformGroup
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

        private void _dropImage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {

        }

        private void BtnGetTransform_Click(object sender, RoutedEventArgs e)
        {
          TransformGroup Group = _dropImage.RenderTransform as TransformGroup;
            //System.Diagnostics.Debug.WriteLine(Group.Value); 
            TransformCollection Collection = Group.Children;
            MatrixTransform mt = Collection[0] as MatrixTransform;
            CompositeTransform ct = Collection[1] as CompositeTransform;
            //System.Diagnostics.Debug.WriteLine(test.Count);
            //System.Diagnostics.Debug.WriteLine(test[0].ToString());
            //System.Diagnostics.Debug.WriteLine(test[1].ToString());
        }
    }
}
