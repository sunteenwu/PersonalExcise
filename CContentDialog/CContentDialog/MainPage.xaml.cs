using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
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

namespace CContentDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IAsyncOperation<ContentDialogResult> result;
        public MainPage()
        {
            this.InitializeComponent();
          
        }

        private async void BtnShowContent_Click(object sender, RoutedEventArgs e)
        {
            ////result  = termsOfUseContentDialog.ShowAsync();
            ////txtShow.Text = result.GetResults().ToString();
            //ContentDialogResult result = await termsOfUseContentDialog.ShowAsync();
            //txtShow.Text = result.ToString();
            //if (result == ContentDialogResult.Primary)
            //{
            //    // Terms of use were accepted.
            //}
            //else
            //{
            //    // User pressed Cancel or the back arrow.
            //    // Terms of use were not accepted.
            //}
            var deviceList = await DeviceInformation.FindAllAsync(GattDeviceService.GetDeviceSelectorFromUuid(GattServiceUuids.GenericAccess), null);
            int count = deviceList.Count();
            if (count > 0)
            {
                var deviceInfo = deviceList.Where(x => x.Name == "XC-Tracer").FirstOrDefault();
                if (deviceInfo != null)
                {
                    if (deviceInfo.IsEnabled)
                    {
                        var bleDevice = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
                        var deviceServices = bleDevice.GattServices;
                    }
                }
            }
        }

        private void ConfirmAgeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TermsOfUseContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {

        }

        private void ConfirmAgeCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAatherContent_Click(object sender, RoutedEventArgs e)
        {
            //IAsyncOperation<ContentDialogResult> result = termsOfUseContentDialog.ShowAsync();
         
        }

        private void termsOfUseContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
          txtShow.Text = result.GetResults().ToString();
        }
    }
}
