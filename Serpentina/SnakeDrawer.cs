using CE.Console;

namespace Serpentina
{
	/// <summary>
	/// Draws the snakes
	/// </summary>
	public static class SnakeDrawer
	{
		/// <summary>
		/// Draw the specified snake in a universe.
		/// </summary>
		public static void Draw (this Snake snake, BufferSection section)
		{
			section.CursorLocation = snake.HeadLocation;
			section.PutChar (snake.HeadChar);
			for (int i = 1; i < snake.Length; i++)
			{
				section.CursorLocation = snake.BodyPoints[i];
				section.PutChar (snake.BodyChar);
			}
		}
	}
}