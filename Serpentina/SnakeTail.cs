using CE;
using CE.Collections;

namespace Serpentina
{
	public class SnakeTail : ModulusList<Point>
	{
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