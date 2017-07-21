using System;
using CE;
using CE.Console;
using CE.Console.Controls;

namespace Serpentina
{
	class MainClass
	{
		public const int SNAKE_COUNT = 1;
		public static App App;
		static KeyComb _escapeKey;

		public static void Main ()
		{
			var design = CE.Console.Controls.Import.JsonImporter.ImportFromFile ("GameUI.json");
			_escapeKey = new KeyComb (ConsoleKey.Escape);
#if DEBUG
			if (Console.BufferWidth == 0)
				App = new App (new Size (60, 40), design);
			else
				App = new App (design: design);
#else
			App = new App (design: design);
#endif
			var snakeColl = new SnakeCollection ();
			CreateSnakes (snakeColl);

			App.Systems.Register (new SnakeMovement (App));
			App.Systems.Register (snakeColl);

			App.Initialize ();
			var kl = App.Systems.Get<KeyboardListener> ();
			kl.KeyPressed += KeyPressed;
			App.Run ();
		}

		static void CreateSnakes (SnakeCollection snakes)
		{
			var snake0 = new Snake
			{
				AccumulatedAdvTime = TimeSpan.FromSeconds (3),
				BodyPoints = new SnakeTail (new Point (3, 3), 3),
				CurrentHeadDir = MoveDir.Right,
				BodyChar = new CE.Color.ColoredChar ('B', ConsoleColor.Green),
				HeadChar = new CE.Color.ColoredChar ('H', ConsoleColor.Green)
			};
			snakes.Snakes.Add (snake0);
		}

		static void KeyPressed (object sender, KeyEventArgs e)
		{
			if (_escapeKey.IsInstance (e.Key))
				App.Exit ();
		}
	}
}