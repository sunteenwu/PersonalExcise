using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CDatagramServer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private uint inboundBufferSize;
        DatagramSocket listener = new DatagramSocket();
        HostName hostName;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnListen_Click(object sender, RoutedEventArgs e)
        {

            listener.MessageReceived += MessageReceived;
           
            try
            {
                // Running both client and server on localhost will most likely not reach the buffer limit.
                // Refer to the DatagramSocketControl class' MSDN documentation for the full list of control options.
               // listener.Control.InboundBufferSizeInBytes = inboundBufferSize;
            }
            catch (ArgumentException)
            {

            }
            // Start listen operation.
            //await listener.BindServiceNameAsync("22112");
         
            hostName = new HostName("localhost");
            await listener.BindEndpointAsync(hostName, "1337");
            Showresult.Text = "Listening";
            //await listener.BindServiceNameAsync(ServiceNameForListener.Text, selectedAdapter);
        }

        private async void MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
        {
            //Read the message that was received from the UDP echo client.
            Stream streamIn = args.GetDataStream().AsStreamForRead();
            StreamReader reader = new StreamReader(streamIn);
            string message = await reader.ReadLineAsync();

            //Create a new socket to send the same message back to the UDP echo client.
            Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();

            //Use a separate port number for the UDP echo client because both will be unning on the same machine.
            string clientPort = "1338";
            Stream streamOut = (await socket.GetOutputStreamAsync(args.RemoteAddress, clientPort)).AsStreamForWrite();
            StreamWriter writer = new StreamWriter(streamOut);
            await writer.WriteLineAsync(message);
            await writer.FlushAsync();
            //Stream streamOut = (await listener.GetOutputStreamAsync(hostName, "22112")).AsStreamForWrite();
            //StreamWriter writer = new StreamWriter(streamOut);
            //string message = "Hello, world!";
            //await writer.WriteLineAsync(message);
            //await writer.FlushAsync();

        }

        private async void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();

            socket.MessageReceived += Socket_MessageReceived;

            //You can use any port that is not currently in use already on the machine.
            string serverPort = "1337";

            //Bind the socket to the serverPort so that we can start listening for UDP messages from the UDP echo client.
            await socket.BindServiceNameAsync(serverPort);

        }

        private async void Socket_MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
        {
            //Read the message that was received from the UDP echo client.
            Stream streamIn = args.GetDataStream().AsStreamForRead();
            StreamReader reader = new StreamReader(streamIn);
            string message = await reader.ReadLineAsync();

            //Create a new socket to send the same message back to the UDP echo client.
            Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();

            //Use a separate port number for the UDP echo client because both will be unning on the same machine.
            string clientPort = "1338";
            Stream streamOut = (await socket.GetOutputStreamAsync(args.RemoteAddress, clientPort)).AsStreamForWrite();
            StreamWriter writer = new StreamWriter(streamOut);
            await writer.WriteLineAsync(message);
            await writer.FlushAsync();
        }
    }
}
