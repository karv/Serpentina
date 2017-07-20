using CE;
using CE.Collections;

namespace Serpentina
{
	public class SnakeTail : ModulusList<Point>
	{
		public SnakeTail (Point starting, int len)
		{
			for (int i = 0; i < len; i++)
				Add (starting);
		}

		public void PushPoint (Point p)
		{
			LastToFirst ();
			this[0] = p;
		}

		public void PushDirection (MoveDir dir)
		{
			PushPoint (this[0] + dir.ToPoint ());
		}
	}
}