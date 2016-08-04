using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
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

namespace ClientUwp
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

		async void Page_Loaded( object sender, RoutedEventArgs e )
		{
			try
			{
				CancellationTokenSource Cts = new CancellationTokenSource();
				CancellationToken Ct = Cts.Token;

				string Address = "ws://localhost:5000";

				var Socket = new System.Net.WebSockets.ClientWebSocket();

				InfoBlock.Text += Environment.NewLine + $"Creating connection to: {Address}";
				await Socket.ConnectAsync( new Uri( Address ), Ct );
				Task.Delay( 100 ).Wait();

				byte[] Data = new byte[ 1024 ];
				InfoBlock.Text += Environment.NewLine + "Receiving data...";
				var Result = await Socket.ReceiveAsync( new ArraySegment<byte>( Data ), Ct );
				InfoBlock.Text += Environment.NewLine + $"Data received: {Result.Count}";

				//Console.WriteLine( "Sending data..." );
				//byte[] Data = System.Text.Encoding.UTF8.GetBytes( "Hello WebSocket!" );
				//Socket.SendAsync( new ArraySegment<byte>( Data ), WebSocketMessageType.Binary, false, Ct ).Wait();
				//Console.WriteLine( "Data sent." );
			}
			catch( Exception Error )
			{
				InfoBlock.Text += Environment.NewLine + $"Fatal error: {Error.ToString()}";
			}
		}
	}
}
