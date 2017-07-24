using System;
using System.Collections.Generic;
using System.Linq;
using CE;
using CE.Console.Controls;

namespace Serpentina
{
	/// <summary>
	/// Contains information about a collision.
	/// </summary>
	public class SnakeCollision
	{
		/// <summary>
		/// Is <c>true</c> if there is a collision.
		/// </summary>
		public readonly bool AnyCollision;

		/// <summary>
		/// If <see cref="AnyCollision"/>, 
		/// this is the snake that crashed.
		/// </summary>
		public readonly Snake HeadCollider;
		/// <summary>
		/// If <see cref="AnyCollision"/>, 
		/// this is the object where <see cref="HeadCollider"/> crashed.
		/// </summary>
		public readonly Snake PassiveCollider;

		SnakeCollision ()
		{
			AnyCollision = false;
		}

		/// <summary>
		/// </summary>
		/// <param name="headCollider">Head collider.</param>
		/// <param name="passiveCollider">Passive collider.</param>
		public SnakeCollision (Snake headCollider, Snake passiveCollider)
		{
			HeadCollider = headCollider;
			PassiveCollider = passiveCollider;
			AnyCollision = true;
		}

		/// <summary>
		/// The constant for no collision.
		/// </summary>
		public static readonly SnakeCollision NoCollision;

		static SnakeCollision ()
		{
			NoCollision = new SnakeCollision ();
		}
	}

	/// <summary>
	/// This class controls the movement of snakes.
	/// </summary>
	public class SnakeMovement : ISystem
	{
		SnakeCollection _snakes;
		App _app;

		/// <summary>
		/// </summary>
		public SnakeMovement (App app)
		{
			_app = app ?? throw new ArgumentNullException (nameof (app));
		}

		IEnumerable<Snake> AliveSnakes { get { return _snakes.Where (z => z.IsAlive); } }

		/// <summary>
		/// Moves all snakes.
		/// </summary>
		/// <returns><c>true</c>, if any snakes was moved, <c>false</c> otherwise.</returns>
		public bool MoveAllSnakes (TimeSpan time)
		{
			if (time < TimeSpan.Zero)
				throw new ArgumentException ("Value must be non-negative", nameof (time));

			var ret = false;
			foreach (var snake in AliveSnakes)
				ret |= MoveSnake (time, snake);

			return ret;
		}

		bool MoveSnake (TimeSpan time, Snake snake)
		{
			if (snake.PassTime (time))
			{
				var sp = SnakeOnPoint (snake.OverheadLocation);
				if (sp != null)
				{
					var collision = new SnakeCollision (snake, sp);
					OnCollision?.Invoke (this, collision);
				}

				snake.AccumulatedAdvTime -= snake.AdvanceTime;
				snake.BodyPoints.PushPoint (snake.OverheadLocation);
				return true;
			}
			return false;
		}

		/// <summary>
		/// In any, gets the snake that contains a specified point. Otherwise returns <c>null</c>.
		/// </summary>
		public Snake SnakeOnPoint (Point p)
		{
			try
			{
				return AliveSnakes.First (z => z.ContainsPoint (p));
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// Initialize this system
		public void Initialize ()
		{
			_snakes = _app.Systems.Get<SnakeCollection> ();
			_app.Update += Update;
		}

		void Update (object sender, TimeSpan e)
		{
			MoveAllSnakes (e);
		}

		/// <summary>
		/// Occurs when a collision happen.
		/// </summary>
		public event EventHandler<SnakeCollision> OnCollision;
	}
}