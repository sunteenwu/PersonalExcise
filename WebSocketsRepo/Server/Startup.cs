using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Server
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices( IServiceCollection services )
		{
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app )
		{
			app.UseIISPlatformHandler();

			app.UseWebSockets();

			app.Use( async ( Context, Next ) =>
			{
				var HttpContext = ( HttpContext )Context;

				if( HttpContext.WebSockets.IsWebSocketRequest )
				{
					WebSocket Socket = await HttpContext.WebSockets.AcceptWebSocketAsync();
					await Task.Delay( 100 );

					CancellationTokenSource Cts = new CancellationTokenSource();
					CancellationToken Ct = Cts.Token;

					System.Diagnostics.Debug.WriteLine( "New client; sending data..." );
					byte[] Data = System.Text.Encoding.UTF8.GetBytes( "Hello WebSocket!" );
					await Socket.SendAsync( new ArraySegment<byte>( Data ), WebSocketMessageType.Binary, false, Ct );
					System.Diagnostics.Debug.WriteLine( "Data sent." );

					//System.Diagnostics.Debug.WriteLine( "New client; receiving data..." );
					//byte[] Data = new byte[ 16 ];
					//var Result = await Socket.ReceiveAsync( new ArraySegment<byte>( Data ), Ct );
					//System.Diagnostics.Debug.WriteLine( $"Data received: {Result.Count}" );
				}
			} );
		}

		// Entry point for the application.
		public static void Main( string[] args ) => WebApplication.Run<Startup>( args );
	}
}
