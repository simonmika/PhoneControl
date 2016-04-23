using System;
using Kean.Extension;

namespace PhoneControl
{
	public class Device
	{
		public event Action<Orientation> OrientationChanged;
		Orientation orientation;
		public Orientation Orientation {
			get { return this.orientation; }
			internal set {
				if (value != this.orientation)
					this.OrientationChanged.Call(this.orientation = value);
			}
		}
		public Device()
		{
		}
	}
}

