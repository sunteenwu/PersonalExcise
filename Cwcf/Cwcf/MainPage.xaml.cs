using Cwcf.ToDoService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel;
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

namespace Cwcf
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

        private async void BtnConnectWcf_Click(object sender, RoutedEventArgs e)
        {
            ToDoService.Service1Client client = new ToDoService.Service1Client();       
            await new Windows.UI.Popups.MessageDialog(client.GetDataAsync(10).Result.ToString()).ShowAsync();
            await client.CloseAsync();
        }

        private async void BtnCookie_Click(object sender, RoutedEventArgs e)
        {
            //var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            //binding.AllowCookies = true;

            //new ClassLibrary1.Class1().Login(binding);

           // var binding = new NetTcpBinding(SecurityMode.Transport);
           // binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
           //var client = new Service1Client(binding, new EndpointAddress(new Uri("net.tcp://localhost:1234/ServiceReference1")));
        }


    }

    //public class Class1
    //{
    //    public void Login(BasicHttpBinding binding)
    //    {
    //        var Client = new ServiceReference1.AuthenticationServiceClient(binding, new EndpointAddress("*****.svc"));
    //        var client2 = new ToDoService.Service1Client(binding, new EndpointAddress("*****.svc"));           


    //        Client.LoginAsync("*****", "*****", null, false);

    //        Client.LoginCompleted += (sender, args) =>
    //        {
    //            if (args.Result)
    //            {
    //                CookieContainer CookieContainer = Client.CookieContainer;
    //                CookieCollection Cookies = CookieContainer.GetCookies(Client.Endpoint.Address.Uri);

    //                Cookie Cookie = Cookies[".ASPXAUTH"];
    //            }
    //        };
    //    }
    //}
}

