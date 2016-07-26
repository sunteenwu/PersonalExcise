using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CDatagramClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DatagramSocket mClient;
        HostName hostName;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            mClient = new DatagramSocket();
       
            DatagramSocketControl ctrl = mClient.Control;
            ctrl.InboundBufferSizeInBytes = 10485760;
            ctrl.DontFragment = true;
            ctrl.QualityOfService = SocketQualityOfService.LowLatency;
          
            try
            {
                hostName = new HostName("localhost");
                await mClient.ConnectAsync(hostName, "22112");
                
                  //  mClient.MessageReceived += Socket_MessageReceived;
                await new Windows.UI.Popups.MessageDialog("Connected!").ShowAsync();

                DataWriter writer;
                writer = new DataWriter(mClient.OutputStream);

              
                string message = "message client";
                writer.WriteString(message);
                await writer.StoreAsync();

            }
            catch(Exception exception)
            {
                if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                {
                    throw;
                }
            }
        
    
        }
        private async void Socket_MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
        {
            //DataReader reader = args.GetDataReader();

            //uint length = reader.UnconsumedBufferLength;

            //byte[] command = new byte[length];
            //reader.ReadBytes(command);

            //ProcessCommands(command);

            //Read the message that was received from the UDP echo server.
            //Stream streamIn = args.GetDataStream().AsStreamForRead();
            //StreamReader reader = new StreamReader(streamIn);
            //string message = await reader.ReadLineAsync();
        }

        private void ProcessCommands(byte[] Command)
        {
            //Do something with then command
        }

        private async void BtnReceive_Click(object sender, RoutedEventArgs e)
        {

            Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();

            //socket.MessageReceived += Socket_MessageReceived;

            ////You can use any port that is not currently in use already on the machine. We will be using two separate and random 
            ////ports for the client and server because both the will be running on the same machine.
            //string serverPort = "1337";
            //string clientPort = "1338";

            ////Because we will be running the client and server on the same machine, we will use localhost as the hostname.
            //Windows.Networking.HostName serverHost = new Windows.Networking.HostName("localhost");

            ////Bind the socket to the clientPort so that we can start listening for UDP messages from the UDP echo server.
            //await socket.BindServiceNameAsync(clientPort);
         
            ////Write a message to the UDP echo server.
            //Stream streamOut = (await socket.GetOutputStreamAsync(serverHost, serverPort)).AsStreamForWrite();
            //StreamWriter writer = new StreamWriter(streamOut);
            //string message = "message client";
            //await writer.WriteLineAsync(message);
            //await writer.FlushAsync();
        }
    }
}
