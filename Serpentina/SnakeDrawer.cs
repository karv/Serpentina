using CE.Console;

namespace Serpentina
{
	public static class SnakeDrawer
	{
		/// <summary>
		/// Draw the specified snake in a universe.
		/// </summary>
		public static void Draw (this Snake snake, BufferSection section)
		{
			section.CursorLocation = snake.HeadLocation;
			section.PutChar (snake.HeadChar);
		}
	}
}