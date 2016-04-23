using System;
using Kean.Extension;
using Serialize = Kean.Serialize;

namespace PhoneControl
{
	public class Orientation: 
		IEquatable<Orientation>
	{
		[Serialize.Parameter]
		public float Alpha { get; internal set; }
		[Serialize.Parameter]
		public float Beta { get; internal set; }
		[Serialize.Parameter]
		public float Gamma { get; internal set; }
		public override string ToString ()
		{
			return string.Format ("{0}, {1}, {2}", this.Alpha, this.Beta, this.Gamma);
		}
		public override int GetHashCode ()
		{
			return this.Alpha.Hash() ^ 33 * (this.Beta.Hash() ^ 33 * this.Gamma.Hash()) ;
		}
		public override bool Equals(object other)
		{
			return base.Equals(other);
		}
		public bool Equals(Orientation other) {
			return this.Alpha == other.Alpha && this.Beta == other.Beta && this.Gamma == other.Gamma;
		}
		public static bool operator ==(Orientation left, Orientation right) {
			return left.SameOrEquals(right);
		}
		public static bool operator !=(Orientation left, Orientation right) {
			return !left.SameOrEquals(right);
		}
	}
}

