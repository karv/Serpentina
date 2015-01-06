using System;

namespace Structs
{
	public class Par <S, T>
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
			return string.Format ("({0}, {1})", x.ToString (), y.ToString ());
		}

		public Par (S a, T b)
		{
			x = a;
			y = b;
		}
        public Par()
        {
        }
	}

    public class Rectángulo<S, T> : Par<Par<S, T>,Par<S,T>>
    {
        public S x1
        {
            get { return x.x; }
        }
        public S x2
        {
            get { return y.x; }
        }
        public T y1
        {
            get { return x.y; }
        }
        public T y2
        {
            get { return y.y; }
        }

        public Rectángulo(S nx1, T ny1, S nx2, T ny2) : base(new Par<S,T>(nx1, ny1), new Par<S,T> (nx2, ny2))
        {

        }
    }
}

