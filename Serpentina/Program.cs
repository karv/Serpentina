using System;
using CE.Console;
using CE.Console.Controls;

namespace Serpentina
{
	class MainClass
	{
		public static App App;
		static KeyComb _escapeKey;

		public static void Main ()
		{
			var design = CE.Console.Controls.Import.JsonImporter.ImportFromFile ("GameUI.json");
			_escapeKey = new KeyComb (ConsoleKey.Escape);
			App = new App (design: design);

			App.Systems.Register (new SnakeMovement (App));
			App.Systems.Register (new SnakeCollection ());

			App.Initialize ();
			var kl = App.Systems.Get<KeyboardListener> ();
			kl.KeyPressed += KeyPressed;
			App.Run ();
		}

		static void KeyPressed (object sender, KeyEventArgs e)
		{
			if (_escapeKey.IsInstance (e.Key))
				App.Exit ();
		}
	}
}