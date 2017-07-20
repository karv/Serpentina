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
			foreach (var snake in _snakes)
				snake.Draw (this);

			DrawBorder (Section, _edgeColor);
		}

		static void DrawBorder (BufferSection section, FullColorInfo color)
		{
			var area = section.GetArea ();
			var top = '/' + new string ('=', area.Size.Width - 2) + '\\';
			section.CursorLocation = Point.Zero;
			section.Write (top);
			for (int i = 1; i <= area.Size.Height - 2; i++)
			{
				section.CursorLocation = new Point (area.Left, i);
				section.Write ("|");
				section.CursorLocation = new Point (area.Right, i);
				section.Write ("|");
			}
			var bot = '\\' + new string ('=', area.Size.Width - 2) + '/';
			section.Write (bot);
		}

		/// Request the optimal size for this control.
		protected override Size RequestSize ()
		{
			return _fieldSize;
		}
	}
}