using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiempo
{   
    /// <summary>
    /// Controla tiempos para ejecutar eventos.
    /// </summary>
    public class Temporalizador
    {
        DateTime _Inicio;
        TimeSpan _Timer;

        /// <summary>
        /// Establece la duración del ciclo de evento.
        /// </summary>
        public TimeSpan Timer
        {
            get { return _Timer; }
            set { _Timer = value; }
        }
        /// <summary>
        /// Devuelve el tiempo inicial
        /// </summary>
        public DateTime Inicio
        {
            get { return _Inicio; }
        }
        /// <summary>
        /// Reestablece el contador de tiempo.
        /// </summary>
        public void Reestablecer ()
        {
            _Inicio = System.DateTime.Now;
        }
        /// <summary>
        /// Devuelve <c>true</c> si ya pasó <c>Timer</c> desde que se ejecutó <c>Reestablecer()</c>.
        /// </summary>
        /// <returns></returns>
        public bool FlagCiclo()
        {
            return _Inicio.Add(_Timer) < DateTime.Now;
        }
        /// <summary>
        /// Paraliza hasta que FlagInicio() sea <c>true</c>.
        /// </summary>
        public void EsperaFlag()
        {
			while (!FlagCiclo()) {}
        }
		/// <summary>
		/// Paraliza hasta que FlagInicio() sea <c>true</c>.
		/// </summary>
		/// <param name="Mientras">Ejecutar en la espera.</param>
		public void EsperaFlag (Action Mientras)
		{
			while (!FlagCiclo()) {
				Mientras.Invoke ();
			}
		}
    }
}
