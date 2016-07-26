using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CMapControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapControl2 : Page
    {
        private ObservableCollection<PolyLines> PolyLineCollection = new ObservableCollection<PolyLines>();
        PolyLines onePolyline = new PolyLines();
        public MapControl2()
        {
            this.InitializeComponent();
            myMap.Loaded += MainMapControl_Loaded;
            myMap.TargetCameraChanged += MyMap_TargetCameraChanged;      
        }
        private void MyMap_TargetCameraChanged(MapControl sender, MapTargetCameraChangedEventArgs args)
        {
            Geopoint center = myMap.Center;
            BasicGeoposition getposition = center.Position;
           //Your code
        }

        private void MainMapControl_Loaded(object sender, RoutedEventArgs e)
        {
           // myMap.Center =
           //new Geopoint(new BasicGeoposition()
           //{
           //    //Geopoint for Seattle 
           //    Latitude = 47.604,
           //    Longitude = -122.329
           //});
           // myMap.ZoomLevel = 17;

        }

        private void BtnPolyLine_Click(object sender, RoutedEventArgs e)
        {
            //double centerLatitude = myMap.Center.Position.Latitude;
            //double centerLongitude = myMap.Center.Position.Longitude;
            ////MapPolyline mapPolyline = new MapPolyline();
            //PolyLines onePolyline = new PolyLines();

            //onePolyline.PolyLinePath = new Geopath(new List<BasicGeoposition>() {
            //    new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude-0.001 },
            //    new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },
            //});
            //onePolyline.polylinestring = "test";
            //PolyLineCollection.Add(onePolyline);
            //MapItems.ItemsSource = PolyLineCollection;
            double centerLatitude = myMap.Center.Position.Latitude;
            double centerLongitude = myMap.Center.Position.Longitude;
            //MapPolyline mapPolyline = new MapPolyline();

            onePolyline.PolyLinePath = new Geopath(new List<BasicGeoposition>() {
                new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude-0.001 },
                new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },
            });


        }

        private void BtnCamara_Click(object sender, RoutedEventArgs e)
        {

            MapCamera myMapCamera = myMap.ActualCamera;
          System.Diagnostics.Debug.WriteLine( myMapCamera.ToString());
        }
    }
    public class PolyLines
    {
        public Geopath PolyLinePath { get; set; }
        public string polylinestring { get; set; }
    }
}
