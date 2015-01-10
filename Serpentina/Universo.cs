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
            Tempo.Timer = TimeSpan.FromSeconds(0.3);

            List<Serpiente> Muertos = new List<Serpiente>();

            while (true)
            {
                Tempo.Reestablecer();

                Serpiente.enumDirecciónAbsoluta dir = Serpiente.enumDirecciónAbsoluta.Derecha;
                foreach (Serpiente x in Jugadores)
                {

                    if (ObjetoEn(x.ObtenerPosiciónFutura(dir)) != null)
                        // Chocó con algo.
                        Muertos.Add(x);
                    else
                    {
                        x.Avanzar(dir);

                        // Console.WriteLine(x.Posición.ToString());

                        // Mueren los que se salen
                        if (!Area.PuntoDentro(x.Posición)) Muertos.Add(x);  // Promesa de muerte.
                    }
                }

                // Matar a los que se les promete muerte
                foreach (Serpiente x in Muertos)
                {
                    OnMuerte.Invoke(x);
                    Jugadores.Remove(x);
                }
                Muertos.Clear();                

                Tempo.EsperaFlag(); //Espera a que pase un segundo desde el inicio del ciclo.
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
    }
}
