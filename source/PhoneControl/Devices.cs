using System;
using Kean.Extension;
using Collection = Kean.Collection;
using Generic = System.Collections.Generic;

namespace PhoneControl
{
	class Devices :
		Generic.IEnumerable<Device>
	{
		public event Action<Device> DeviceCreated;
		Collection.IDictionary<string, Device> devices = new Collection.Dictionary<string, Device>();
		internal Device this[string identifier] {
			get 
			{ 
				var result = this.devices[identifier];
				if (result.IsNull())
					this.DeviceCreated.Call(this.devices[identifier] = result = new Device());
				return result;
			}
		}
		public Devices()
		{
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}
		public Generic.IEnumerator<Device> GetEnumerator() {
			return this.devices.GetEnumerator().Map(element => element.Value);
		}
	}
}

