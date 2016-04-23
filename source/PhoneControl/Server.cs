using System;
using Kean.Extension;
using Uri = Kean.Uri;
using Tcp = Kean.IO.Net.Tcp;
using Http = Kean.IO.Net.Http;

namespace PhoneControl
{
	public class Server
	{
		Uri.Locator clientFolder;
		Tcp.Server backend;
		public Server(Uri.Locator clientFolder)
		{
			this.clientFolder = clientFolder;
		}
		void Process(Http.Server server) {
			switch (server.Request.Method)
			{
				case Http.Method.Get:
					server.SendFile(this.clientFolder);
					break;
				case Http.Method.Post:
					switch (server.Request.Path)
					{
						case "/orientation":
							Orientation orientation = server.Receive<Orientation>();
							Console.WriteLine(orientation);
							break;
					}
					break;
			}
		}
		public bool Start(uint port) {
			return (this.backend = Http.Server.Start(this.Process, port)).NotNull();
		}
		public bool StartThreaded(uint port) {
			return (this.backend = Http.Server.StartThreaded(this.Process, port)).NotNull();
		}
		public bool Stop() {
			bool result = this.backend.NotNull() && this.backend.Stop();
			this.backend = null;
			return result;
		}
		public bool Run(uint port) {
			return Http.Server.Run(this.Process, port); 
		}
		public bool RunThreaded(uint port) {
			return Http.Server.RunThreaded(this.Process, port); 
		}
	}
}

