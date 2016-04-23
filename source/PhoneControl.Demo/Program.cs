using System;

namespace PhoneControl.Demo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Kean.Error.Log.CatchErrors = false;
			var server = new Server("file:///./Client/");
			Console.WriteLine ("Server Listening on port 8080.");
			server.Run(8080);
		}
	}
}
