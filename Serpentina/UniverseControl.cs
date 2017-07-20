using System;
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

		internal SnakeCollection _snakes;
		internal readonly Size _fieldSize;
		internal ConsoleColor _backgroundColor = ConsoleColor.Black;

		[Newtonsoft.Json.JsonConstructor]
		public UniverseControl ()
		{
			_snakes = new SnakeCollection ();
			_fieldSize = new Size (X_SIZE, Y_SIZE);
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
		}

		/// Request the optimal size for this control.
		protected override Size RequestSize ()
		{
			return _fieldSize;
		}
	}
}