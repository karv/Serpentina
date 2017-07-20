using System;
using CE.Console;
using CE.Console.Controls;
using CE;

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
			App = new App (design: design);

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
				AccumulatedAdvTime = TimeSpan.FromSeconds (1),
				BodyPoints = new SnakeTail (new Point (3, 3), 3),
				CurrentHeadDir = MoveDir.Up,
				BodyChar = new CE.Color.ColoredChar ('o', ConsoleColor.Green),
				HeadChar = new CE.Color.ColoredChar ('O', ConsoleColor.Green)
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