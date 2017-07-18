using System;
using System.Collections.Generic;
using CE;
using CE.Console.Controls;

namespace Serpentina
{
	/// <summary>
	/// CE's control that display the game itself.
	/// </summary>
	public class UniverseControl : Control
	{
		const int X_SIZE = 40;
		const int Y_SIZE = 40;

		readonly List<Snake> _snakes;
		readonly Size _fieldSize;
		private ConsoleColor backgroundColor = ConsoleColor.Black;

		[Newtonsoft.Json.JsonConstructor]
		public UniverseControl ()
		{
			_snakes = new List<Snake> ();
			_fieldSize = new Size (X_SIZE, Y_SIZE);
		}

		public ConsoleColor BackgroundColor
		{
			get => backgroundColor;
			set
			{
				backgroundColor = value;
				QueueDraw ();
			}
		}

		public override void DoDraw ()
		{
			Section.Clear (BackgroundColor);
			foreach (var snake in _snakes)
				snake.Draw (this);
		}

		protected override Size RequestSize ()
		{
			return _fieldSize;
		}
	}
}