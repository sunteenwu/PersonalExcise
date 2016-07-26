using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Windows.Networking.ServiceDiscovery.Dnssd;
using Windows.Networking.Sockets;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CDNSService
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
        DnssdServiceInstance _service;
        StreamSocketListener _listener;
        private async void BtnDNSD_Click(object sender, RoutedEventArgs e)
        {
            //Service Broadcast
           _listener = new StreamSocketListener();
            _listener.ConnectionReceived += _listener_ConnectionReceived;

            await _listener.BindServiceNameAsync("56788");

            //_service = new DnssdServiceInstance(Username + "._myapp._tcp.local",
            //  NetworkInformation.GetHostNames().FirstOrDefault(x => x.Type == HostNameType.DomainName && x.RawName.Contains("local")),
            //  UInt16.Parse(_listener.Information.LocalPort));

            _service = new DnssdServiceInstance("._myapp._tcp.local",
              NetworkInformation.GetHostNames().FirstOrDefault(x => x.Type == HostNameType.DomainName && x.RawName.Contains("local")),
              UInt16.Parse(_listener.Information.LocalPort));
            await _service.RegisterStreamSocketListenerAsync(_listener);
        }

        private void _listener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
