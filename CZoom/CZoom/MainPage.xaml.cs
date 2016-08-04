using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CZoom
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Images> images;
        public MainPage()
        {
            this.InitializeComponent();

            images = new ObservableCollection<Images> {
            new Images { imagename = "image1", imageurl = "Assets/cafee2.jpg" ,imgheight="100",imgwidth="100"},
            new Images {imagename="image2",imageurl="ms-appx:///Assets/caffe.jpg" },
            new Images {imagename="image3",imageurl="ms-appx:///Assets/caffe3.jpg" } };
            gridviewzoom.ItemsSource = images;
            this.DataContext = images;
        }

        private void gridviewzoom_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            images = new ObservableCollection<Images> {
            new Images { imagename = "image1", imageurl = "Assets/cafee2.jpg" ,imgheight="200",imgwidth="200"},
            new Images {imagename="image2",imageurl="ms-appx:///Assets/caffe.jpg" },
            new Images {imagename="image3",imageurl="ms-appx:///Assets/caffe3.jpg" } };
            gridviewzoom.ItemsSource = images;
        }

        private void gridviewzoom_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {            images = new ObservableCollection<Images> {
            new Images { imagename = "image1", imageurl = "Assets/cafee2.jpg" ,imgheight="200",imgwidth="200"},
            new Images {imagename="image2",imageurl="ms-appx:///Assets/caffe.jpg" },
            new Images {imagename="image3",imageurl="ms-appx:///Assets/caffe3.jpg" } };
            gridviewzoom.ItemsSource = images;

        }

        private void gridviewzoom_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
        {

        }

        private void gridviewzoom_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {

        }
    }

    public class Images
    {
        public string imageurl { get; set; }
        public string imagename { get; set; }

        public string imgwidth { get; set; }
        public string imgheight { get; set; }
    }
}
