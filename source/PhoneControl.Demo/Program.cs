using System;

namespace PhoneControl.Demo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Kean.Error.Log.CatchErrors = false;
			var server = new Server("file:///./Client/");
			int deviceCount = 0;
			server.DeviceCreated += device =>
			{ 
				var number = deviceCount++;
				device.OrientationChanged += orientation => Console.WriteLine(number + ": " + orientation);
			};
			Console.WriteLine ("Server Listening on port 8080.");
			server.Run(8080);
		}
	}
}
