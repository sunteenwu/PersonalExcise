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

namespace DataBinding_and_Layout_Update_Question
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<WalletAddress> AddressCollection;
        Wallet walletCollection;
        public MainPage()
        {
            this.InitializeComponent();

            AddressCollection = new ObservableCollection<WalletAddress>
            {
                new WalletAddress { address = "address1", value = 101 },
                new WalletAddress {address="address2",value=102 },
                new WalletAddress { address="address3", value=103}
            };

            walletCollection = new Wallet { address = AddressCollection, updateTime = System.DateTime.Now };
            Load();
        }
        private async void Load()
        {
            WalletAddressList.ItemsSource = walletCollection.address;
            WalletValue.DataContext = walletCollection;
        }

        private void FlyoutButtonRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FlyoutButtonShowAddressAsQR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WalletAddress_Holding(object sender, HoldingRoutedEventArgs e)
        {

        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string inputAddress = "test updated address";
            if (true)
            {
                double inputAddressValue = 999;
               // double inputAddressValue = await GetBalance(inputAddress);
                // Update the container
                if (walletCollection.address == null)
                { walletCollection.address = new ObservableCollection<WalletAddress>(); }
                walletCollection.address.Add(
                    new WalletAddress() { address = inputAddress, value = inputAddressValue }
                );
                walletCollection.value += inputAddressValue;
            }    
        }
    }
}
