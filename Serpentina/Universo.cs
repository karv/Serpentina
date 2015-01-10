using System;
using System.Collections.Generic;
using Structs;

namespace Serpentina
{
    /// <summary>
    /// Representa el universo de juego.
    /// </summary>
    public class Universo
    {
        public event Action<Serpiente> OnMuerte;
        List<Serpiente> _Jugadores = new List<Serpiente>();
        
        /// <summary>
        /// Devuelve la lista de jugadores.
        /// </summary>
        public List<Serpiente> Jugadores
        {
            get { return _Jugadores; }
        }

        /// <summary>
        /// Representa el área del juego.
        /// </summary>
        public RectanguloInt Area = new RectanguloInt();

        /// <summary>
        /// Ejecuta el juego.
        /// </summary>
        public virtual void Run()
        {
            Tiempo.Temporalizador Tempo = new Tiempo.Temporalizador();  //El temporalizador del juego.
            Tempo.Timer = TimeSpan.FromSeconds(0.15);

            List<Serpiente> Muertos = new List<Serpiente>();

            while (true)
            {
                Tempo.Reestablecer();

				// Key Binding





				Serpiente.enumDirecciónAbsoluta dir;
                foreach (Serpiente x in Jugadores)
                {
					dir = x.DireccionActual;
                    if (ObjetoEn(x.ObtenerPosiciónFutura(dir)) != null)
                        // Chocó con algo.
                        Muertos.Add(x);
                    else
                    {
                        x.Avanzar(dir);

                        // Mueren los que se salen
                        if (!Area.PuntoDentro(x.Posicion)) Muertos.Add(x);  // Promesa de muerte.
                    }
                }

                // Matar a los que se les promete muerte
                foreach (Serpiente x in Muertos)
                {
                    OnMuerte.Invoke(x);
                    Jugadores.Remove(x);
                }
                Muertos.Clear();                

                Tempo.EsperaFlag(AtrapaTeclas); //Espera a que pase un segundo desde el inicio del ciclo.
            }
        }

        /// <summary>
        /// Devuelve el objeto que se encuentra en una posición fija.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public object ObjetoEn (Structs.Par<int, int> p)
        {
            // ¿Es serpiente?
            foreach (Serpiente x in Jugadores)
            {
                if (x.ContienePos(p)) return x;
            }
            
            return null;
        }

		/// <summary>
		/// Atrapa la entrada de teclas de consola.
		/// </summary>
		public void AtrapaTeclas ()
		{
			ConsoleKeyInfo CKI;
			if (Console.KeyAvailable) {
				CKI = Console.ReadKey ();

				switch (CKI.Key) {
				case ConsoleKey.UpArrow:
					Jugadores [0].DireccionActual = Serpiente.enumDirecciónAbsoluta.Arriba;
					break;
				case ConsoleKey.DownArrow:
					Jugadores [0].DireccionActual = Serpiente.enumDirecciónAbsoluta.Abajo;
					break;
				case ConsoleKey.LeftArrow:
					Jugadores [0].DireccionActual = Serpiente.enumDirecciónAbsoluta.Izquierda;
					break;
				case ConsoleKey.RightArrow:
					Jugadores [0].DireccionActual = Serpiente.enumDirecciónAbsoluta.Derecha;
					break;
				}
			}
		}
    }
}
