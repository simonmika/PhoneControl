using System;
using Serialize = Kean.Serialize;

namespace PhoneControl
{
	public class Orientation
	{
		[Serialize.Parameter]
		public decimal Alpha { get; set; }
		[Serialize.Parameter]
		public decimal Beta { get; set; }
		[Serialize.Parameter]
		public decimal Gamma { get; set; }
		public Orientation()
		{
		}
		public override string ToString ()
		{
			return string.Format ("[Orientation: Alpha={0}, Beta={1}, Gamma={2}]", Alpha, Beta, Gamma);
		}
	}
}

