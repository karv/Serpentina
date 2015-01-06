using System;

namespace Serpentina
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SerpienteConsola s = new SerpienteConsola (10, 10, 10);

			s.MaxLongitud = 7;
            Universo U = new Universo();
            U.羠ea = new Structs.Rect醤guloInt(0, 0, 40, 40);

            s.Posici髇.x = 3;
            s.Posici髇.y = 3;

            U.Jugadores.Add(s);
			s.Dibujar ();

			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecci贸nAbsoluta.Arriba);	

			Console.ReadLine ();


            U.Run();

		}
	}
}
