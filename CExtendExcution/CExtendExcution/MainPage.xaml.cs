using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.ExtendedExecution;
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

namespace CExtendExcution
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Library Library = new Library();
        string path;
        SQLiteConnection conn;
        private ExtendedExecutionSession session;
        public MainPage()
        {
            this.InitializeComponent();   
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db1.sqlite");
            txtKetQua.Text = "";
            btLuu.IsEnabled = false;
        }
        private async void StartLocationExtensionSession()
        {
            StopLocationExtensionSession();
            session = new ExtendedExecutionSession();
            session.Description = "LocationTracking";
            session.Reason = ExtendedExecutionReason.LocationTracking;
            session.Revoked += Session_Revoked;
            var result = await session.RequestExtensionAsync();
            if (result == ExtendedExecutionResult.Denied)
            {
                // txtStatus.Text = "Không cho phép theo dõi";
            }
        }
        private void StopLocationExtensionSession()
        {
            if (session != null)
            {
                session.Dispose();
                session = null;
            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            StopLocationExtensionSession();
        }
        private void Session_Revoked(object sender, ExtendedExecutionRevokedEventArgs args)
        {
            if (session != null)
            {
                session.Dispose();
                session = null;
            }
        }

        public async Task<Geopoint> Position()
        {
            return (await new Geolocator().GetGeopositionAsync()).Coordinate.Point;
        }
        double firstlong = 0;
        double firstla = 0;
        double distance = 0;
        private async Task GetPositionAndShowPoint()
        {
            Geopoint point = await Library.Position();
            firstlong = point.Position.Longitude;
            firstla = point.Position.Latitude;
        }
        Geolocator geolocator = null;
        bool tracking = false;
        private async void btBatDau_Click(object sender, RoutedEventArgs e)
        {
            if (!tracking)
            {
                StartLocationExtensionSession();
                txtStatus.Text = "Đang lấy vị trí của bạn";
                distance = 0;
                await GetPositionAndShowPoint();
                geolocator = new Geolocator();
                geolocator.DesiredAccuracy = PositionAccuracy.High;
                geolocator.MovementThreshold = 100;
                geolocator.StatusChanged += geolocator_StatusChanged;
                geolocator.PositionChanged += geolocator_PositionChanged;
                tracking = true;
                btBatDau.Content = "Dừng";
                btLuu.IsEnabled = false;
                txtKetQua.Text = "";
            }
            else
            {
                geolocator.StatusChanged -= geolocator_StatusChanged;
                geolocator.PositionChanged -= geolocator_PositionChanged;
                geolocator = null;
                tracking = false;
                btBatDau.Content = "Bắt đầu";
                txtStatus.Text = "";
                btLuu.IsEnabled = true;
                StopLocationExtensionSession();
                if (txtDistance.Text == "")
                {
                    btLuu.IsEnabled = false;
                }
            }
        }

        private async void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                double newlong = args.Position.Coordinate.Longitude;
                double newla = args.Position.Coordinate.Latitude;
                distance += DistanceTo(firstla, firstlong, newla, newlong, 'K');
                firstla = newla;
                firstlong = newlong;
                distance = Math.Round(distance, 2);
                txtDistance.Text = distance.ToString();
            });
        }
        static public double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }
            return dist;
        }

        private async void geolocator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            string status = "";
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                switch (args.Status)
                {
                    case PositionStatus.Disabled:
                        // the application does not have the right capability or the location master switch is off
                        status = "Cài đặt vị trí đã tắt";
                        break;
                    case PositionStatus.Initializing:
                        // the geolocator started the tracking operation
                        status = "Đang lấy vị trí của bạn";
                        break;
                    case PositionStatus.NoData:
                        // the location service was not able to acquire the location
                        status = "Không có dữ liệu";
                        break;
                    case PositionStatus.Ready:
                        // the location service is generating geopositions as specified by the tracking parameters
                        status = "Đang ghi nhận";
                        break;
                    case PositionStatus.NotAvailable:
                        status = "Không có giá trị";
                        // not used in WindowsPhone, Windows desktop uses this value to signal that there is no hardware capable to acquire location information
                        break;
                    case PositionStatus.NotInitialized:
                        // the initial state of the geolocator, once the tracking operation is stopped by the user the geolocator moves back to this state

                        break;
                }
                txtStatus.Text = status;
            });
        }
        private async Task<bool> FileExists(string fileName)
        {
            var result = false;
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                result = true;
            }
            catch { }
            return result;
        }

        private void btLuu_Click(object sender, RoutedEventArgs e)
        {
            string result = String.Empty;
            var toDay = DateTime.Now.Date;
            Convert.ToDateTime(toDay);
            CultureInfo viVn = new CultureInfo("vi-VN");
            using (conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path))
            {
                conn.Insert(new KilometManager() { Ngay = toDay.ToString("d", viVn), SoKmDiDuoc = double.Parse(txtDistance.Text) });
                conn.Dispose();
            }
            txtKetQua.Text = toDay.ToString("d", viVn) + ": " + txtDistance.Text + " Km";
            txtDistance.Text = "";
            btLuu.IsEnabled = false;
            StopLocationExtensionSession();
        }
    }
}
