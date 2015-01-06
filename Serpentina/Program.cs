using System;

namespace Serpentina
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Serpiente s = new Serpiente (10);
            Universo U = new Universo();
            U.Área = new Structs.RectánguloInt(0, 0, 40, 40);

            s.Posición.x = 3;
            s.Posición.y = 3;

            U.Jugadores.Add(s);

            U.Run();

			Console.WriteLine ("Hello World!");
		}
	}
}
