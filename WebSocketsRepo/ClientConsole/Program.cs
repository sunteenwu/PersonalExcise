using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientConsole
{
	public class Program
	{
		public static void Main( string[] args )
		{
			MainAsync().Wait();
		}

		static async Task MainAsync()
		{
			try
			{
				CancellationTokenSource Cts = new CancellationTokenSource();
				CancellationToken Ct = Cts.Token;

				string Address = "ws://localhost:5000";

				var Socket = new System.Net.WebSockets.ClientWebSocket();

				Console.WriteLine( $"Creating connection to: {Address}" );
				await Socket.ConnectAsync( new Uri( Address ), Ct );
				Task.Delay( 100 ).Wait();

				byte[] Data = new byte[ 1024 ];
				Console.WriteLine( "Receiving data..." );
				var Result = await Socket.ReceiveAsync( new ArraySegment<byte>( Data ), Ct );
				Console.WriteLine( $"Data received: {Result.Count}" );

				//Console.WriteLine( "Sending data..." );
				//byte[] Data = System.Text.Encoding.UTF8.GetBytes( "Hello WebSocket!" );
				//Socket.SendAsync( new ArraySegment<byte>( Data ), WebSocketMessageType.Binary, false, Ct ).Wait();
				//Console.WriteLine( "Data sent." );
			}
			catch( Exception Error )
			{
				Console.WriteLine( $"Fatal error: {Error.ToString()}" );
			}

			Console.WriteLine();
			Console.WriteLine( "Done; press any key to close..." );
			Console.ReadKey( true );
		}
	}
}
