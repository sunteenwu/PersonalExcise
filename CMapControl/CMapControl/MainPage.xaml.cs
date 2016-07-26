using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CMapControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
           // MainMapControl.Loaded += MainMapControl_Loaded;
            this.DataContext = annotations;
        }
       
        public JsonObject ToJsonObject()
        {
            JsonObject point = new JsonObject();
            point.SetNamedValue("latitude",JsonValue.CreateStringValue("47.604"));
            point.SetNamedValue("longitude", JsonValue.CreateStringValue("-122.329"));

            JsonObject segment = new JsonObject();
            segment.SetNamedValue("point", point);
            JsonObject segmentobject = new JsonObject();
            segmentobject.SetNamedValue("area", segment);
            return segmentobject;
        }


        private void BtnPolygon_Click(object sender, RoutedEventArgs e)
        {
            LoadAnnotations();
        }

        //private void MainMapControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    MainMapControl.Center =
        //   new Geopoint(new BasicGeoposition()
        //   {
        //       //Geopoint for Seattle 
        //       Latitude = 47.604,
        //       Longitude = -122.329
        //   });
        //    MainMapControl.ZoomLevel = 17;

        //}

        private ObservableCollection<Annotation> annotations = new ObservableCollection<Annotation>();
        public ObservableCollection<Annotation> Annotations
        {
            get
            {
                return annotations;
            }
            set
            {
                annotations = value;
                //RaisePropertyChanged(() => Annotations);
            }
        }


        public void LoadAnnotations()
        {
            //Code not relevant to issue. Service call and all. Relevant code below:
            JsonObject segmentObject = ToJsonObject();
            Annotation annotation = RetrieveAnnotation(segmentObject);
            Annotations.Add(annotation);
        }

        private Annotation RetrieveAnnotation(JsonObject segment)
        {
            Annotation annotation = new Annotation();
            JsonObject area = segment["area"].GetObject();
            annotation.PolygonPath = new Geopath(GetPositions(area));
            return annotation;
        }

        private List<BasicGeoposition> GetPositions(JsonObject area)
        {
            
            List<BasicGeoposition> positions = new List<BasicGeoposition>();
            //foreach (JsonValue point in points)
            //{
            JsonObject pointObject = area["point"].GetObject();
            var latitude = double.Parse(pointObject["latitude"].GetString());
                var longitude = double.Parse(pointObject["longitude"].GetString());
                BasicGeoposition position = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };
                positions.Add(position);
            //}
            return positions;
        }

        private void MainMapControl_LoadingStatusChanged(Windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {

        }


    }
    public class Annotation
    {
        public Geopath PolygonPath { get; set; }
    }
}
