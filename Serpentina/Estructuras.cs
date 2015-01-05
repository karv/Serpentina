using System;

namespace Structs
{
	public struct Par <S, T>
	{
		public S x;
		public T y;

		public override bool Equals (object obj)
		{
			if (obj is Par<S, T>) {
				Par <S, T> cmp = (Par<S, T>)obj;
				return x.Equals (cmp.x) && y.Equals (cmp.y);
			}
			return false;
		}
		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		public override string ToString ()
		{
			return string.Format ("({0}, {0})", x.ToString (), y.ToString ());
		}

		public Par (S a, T b)
		{
			x = a;
			y = b;
		}
	}
}

