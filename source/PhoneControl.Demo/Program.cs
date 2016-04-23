using System;
using Draw = Kean.Draw;
using Geometry2D = Kean.Math.Geometry2D;
using Single = Kean.Math.Single;

namespace PhoneControl.Demo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			float rotationX = 0;
			float rotationZ = 0;
			Kean.Error.Log.CatchErrors = false;

			Draw.OpenGL.Window window = new Draw.OpenGL.Window();
			var background = Draw.Raster.Bgr.Open("./background.jpg");
			window.Draw += surface =>
			{
				surface.Push(Geometry2D.Single.Transform.CreateRotation(rotationZ) * Geometry2D.Single.Transform.CreateTranslation(0, rotationX / 3.1415f * 5000));
				surface.Clear();
				surface.Draw(background, (Geometry2D.Single.Point)((Geometry2D.Single.Size)background.Size / -2));
				surface.Pop();
			};

			var server = new Server("file:///./Client/");
			int deviceCount = 0;
			server.DeviceCreated += device =>
			{ 
				var number = deviceCount++;
				device.OrientationChanged += orientation => {
					rotationX = Single.ToRadians(orientation.Gamma);
					rotationZ = -Single.ToRadians(orientation.Alpha);
					window.Invalidate();
					Console.WriteLine(number + ": " + orientation);
				};
			};
			server.Start(8080);
			Console.WriteLine ("Server Listening on port 8080.");
			window.Visible = true;
			window.Run();
		}
	}
}
