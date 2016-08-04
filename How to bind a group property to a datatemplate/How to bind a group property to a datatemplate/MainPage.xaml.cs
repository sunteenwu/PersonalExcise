using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace How_to_bind_a_group_property_to_a_datatemplate
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

            this.DataContext = images;
            // _favorite.DataContext = images;
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void WrapGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void BtnGetColor_Click(object sender, RoutedEventArgs e)
        {   // var grFavorite = _favorite.FindName("grFavorite") as GridView;
            string[] datatoPost = new string[3];

            datatoPost[0] = "a";
            datatoPost[1] = "b";
            datatoPost[2] = "email";

            // _favorite
            try
            {
                bool IsNetworkAvailable = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

                if (IsNetworkAvailable == true)
                {
                    Uri requesturi = new Uri("http://baidu.com");//URL changed b'coz company policies
                    //dynamic dynamicjson = new ExpandoObject();
                    //dynamicjson.name = datatoPost[0];
                    //dynamicjson.details = datatoPost[1];
                    //dynamicjson.yemail = datatoPost[2];
                    //json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicjson);



                    var objClint = new HttpClient();

                    //HttpResponseMessage respon = await objClint.PostAsync(requesturi, new StringContent(json, Encoding.UTF8,"application/json")); //Original Post String

                    var test = new StringContent(datatoPost.ToString(), Encoding.UTF8);
                    HttpResponseMessage respon = await objClint.PostAsync(requesturi, new  StringContent(datatoPost.ToString(), Encoding.UTF8));

                    string responJsonText = await respon.Content.ReadAsStringAsync();
                    if (responJsonText.Contains("saved"))
                    {
                        MessageDialog mesg = new MessageDialog("Successfully Posted");
                        await mesg.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog mesg = new MessageDialog("No Internet connection available, Please Connect to Internet to continue.");
                    await mesg.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                string exc = ex.Message;
            }

        }
    }

}
