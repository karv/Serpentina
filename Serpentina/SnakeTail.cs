using CE;
using CE.Collections;

namespace Serpentina
{
	/// <summary>
	/// Controls the dynamic array of the points of the body of a <see cref="Snake"/>
	/// </summary>
	public class SnakeTail : ModulusList<Point>
	{
		/// <summary>
		/// </summary>
		/// <param name="starting">Head location</param>
		/// <param name="len">Length of the snake (head included)</param>
		public SnakeTail (Point starting, int len)
		{
			for (int i = 0; i < len; i++)
				Add (starting);
		}

		/// <summary>
		/// Sets the specified point as the new head.
		/// </summary>
		public void PushPoint (Point p)
		{
			LastToFirst ();
			this[0] = p;
		}

		/// <summary>
		/// Sets a new point as the new head.
		/// </summary>
		public void PushDirection (MoveDir dir)
		{
			PushPoint (this[0] + dir.ToPoint ());
		}
	}
}