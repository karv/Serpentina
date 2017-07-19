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
			App.Initialize ();
			var kl = App.GetSystem<KeyboardListener> ();
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