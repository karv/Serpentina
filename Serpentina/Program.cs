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
            U.�rea = new Structs.Rect�nguloInt(0, 0, 40, 40);

            s.Posici�n.x = 3;
            s.Posici�n.y = 3;

            U.Jugadores.Add(s);
			s.Dibujar ();

			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Derecha);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);
			s.Avanzar (Serpiente.enumDirecciónAbsoluta.Arriba);	

			Console.ReadLine ();


            U.Run();

		}
	}
}
