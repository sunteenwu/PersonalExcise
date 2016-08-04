using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
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
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CToolKit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Bill> billitems;
        public MainPage()
        {
            this.InitializeComponent();
            billitems = new ObservableCollection<Bill> {
                new Bill { SNumber="1",description="First bill", uom="uom", quantity="1", price ="10" ,discount = "1",  cartTotal="10", imageUrl="Assets/HelloWorld.png" },
                new Bill { SNumber="2",description="Second bill", uom="uom", quantity="2", price ="20" ,discount = "1",  cartTotal="40" }
            };
            dgNewBill.ItemsSource = billitems;
        }



        private async void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            //var client = new HttpClient();
            //strUrl = string.Format(Grocery.GlobalConstants.ServiceUrl.CREATE_BILL_URL, strIpAddress, strPortNumber, strJsonString);

            //HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(strUrl);
            //webrequest.Method = "POST";
            //webrequest.ContentType = "application/json; charset=utf-8";
            //var response = await webrequest.GetResponseAsync().ConfigureAwait(false);
            //var stream = response.GetResponseStream();
            //var streamReader = new StreamReader(stream);
            //strBillResult = streamReader.ReadToEnd();
            //result = (RootObject)DBHelper.GetObjectFromJsonString(strBillResult);
        }

        private void pricePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void quantityPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void voidImagePanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void discountPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
    public class Bill
    {
        public string SNumber { get; set; }
        public string description { get; set; }
        public string uom { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string discount { get; set; }
        public string cartTotal { get; set; }
        public string imageUrl { get; set; }
    }
}
