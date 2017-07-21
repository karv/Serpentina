using System;
using CE;
using CE.Console.Controls;
using CE.Console;
using CE.Color;

namespace Serpentina
{
	/// <summary>
	/// CE's control that display the game itself.
	/// </summary>
	public class UniverseControl : Control
	{
		const int X_SIZE = 40;
		const int Y_SIZE = 40;
		const char EDGE_HOR_CHAR = '\u2500';
		const char EDGE_VER_CHAR = '\u2502';
		const char EDGE_DTL_CHAR = '\u250C';
		const char EDGE_DTR_CHAR = '\u2510';
		const char EDGE_DBL_CHAR = '\u2514';
		const char EDGE_DBR_CHAR = '\u2518';

		internal SnakeCollection _snakes;
		internal readonly Size _fieldSize;
		internal ConsoleColor _backgroundColor = ConsoleColor.Black;
		FullColorInfo _edgeColor;

		public UniverseControl ()
		{
			_snakes = new SnakeCollection ();
			_fieldSize = new Size (X_SIZE, Y_SIZE);
			_edgeColor = new FullColorInfo (ConsoleColor.White, _backgroundColor);
		}

		/// Pre iteration cycle setup.
		protected override void ExecuteInitialization ()
		{
			_snakes = App.Systems.Get<SnakeCollection> ();
		}

		public ConsoleColor BackgroundColor
		{
			get => _backgroundColor;
			set
			{
				_backgroundColor = value;
				QueueDraw ();
			}
		}

		public override void DoDraw ()
		{
			Section.Clear (BackgroundColor);
			DrawBorder (Section, _edgeColor);

			foreach (var snake in _snakes)
				snake.Draw (Section);
		}

		static void DrawBorder (BufferSection section, FullColorInfo color)
		{
			var area = section.GetArea ();
			var top = EDGE_DTL_CHAR + new string (EDGE_HOR_CHAR, area.Size.Width - 2) + EDGE_DTR_CHAR;
			section.CursorLocation = Point.Zero;
			section.Write (top, color);
			for (int i = 1; i <= area.Size.Height - 2; i++)
			{
				section.CursorLocation = new Point (area.Left, i);
				section.Write (EDGE_VER_CHAR.ToString (), color);
				section.CursorLocation = new Point (area.Right, i);
				section.Write (EDGE_VER_CHAR.ToString (), color);
			}
			var bot = EDGE_DBL_CHAR + new string (EDGE_HOR_CHAR, area.Size.Width - 2) + EDGE_DBR_CHAR;
			section.Write (bot, color);
		}

		/// Request the optimal size for this control.
		protected override Size RequestSize ()
		{
			return _fieldSize;
		}
	}
}