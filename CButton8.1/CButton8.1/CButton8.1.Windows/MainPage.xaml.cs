using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CButton8._1
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
        public static string SystemFamily { get; }
        public static string SystemVersion { get; }
        public static string SystemArchitecture { get; }
        public static string ApplicationName { get; }
        public static string ApplicationVersion { get; }
        public static string DeviceManufacturer { get; }
        public static string DeviceModel { get; }

        private void BtnCanavas_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void BtnGetOS_Click(object sender, RoutedEventArgs e)
        {
            GetWindowsOS_WINRT();
        }

        public void GetWindowsOS_WINRT()
        {
            var analyticsInfoType = Type.GetType("Windows.System.Profile.AnalyticsInfo, Windows, ContentType=WindowsRuntime");
            var versionInfoType = Type.GetType("Windows.System.Profile.AnalyticsVersionInfo, Windows, ContentType=WindowsRuntime");

            if (analyticsInfoType == null || versionInfoType == null)
            {
                TbckOSVersion.Text = "Apparently you are not on Windows 10";
                return;
            }

            var versionInfoProperty = analyticsInfoType.GetRuntimeProperty("VersionInfo");

            object versionInfo = versionInfoProperty.GetValue(null);
            var versionProperty = versionInfoType.GetRuntimeProperty("DeviceFamilyVersion");
            object familyVersion = versionProperty.GetValue(versionInfo);
            long versionBytes;
            if (!long.TryParse(familyVersion.ToString(), out versionBytes))
            {
                TbckOSVersion.Text = "Can't parse version number";
                return;
            }

            Version DeviceVersion = new Version((ushort)(versionBytes >> 48),
              (ushort)(versionBytes >> 32),
              (ushort)(versionBytes >> 16),
              (ushort)(versionBytes));

            TbckOSVersion.Text = "Current Windows Device Version: " + DeviceVersion;
        }
    }
}
