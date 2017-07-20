using CE;

namespace Serpentina
{
	/// <summary>
	/// Enumera acciones para un jugador
	/// </summary>
	public enum MoveDir
	{
		Up,
		Down,
		Left,
		Right
	}

	public static class DirExt
	{
		public static Point ToPoint (this MoveDir dir)
		{
			switch (dir)
			{
				case MoveDir.Up: return new Point (0, -1);
				case MoveDir.Down: return new Point (0, 1);
				case MoveDir.Left: return new Point (-1, 0);
				case MoveDir.Right: return new Point (1, 0);
			}

			throw new System.Exception ("Direction not implemented: " + dir.ToString ());
		}
	}
}