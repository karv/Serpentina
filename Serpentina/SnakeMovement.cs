using System;
using System.Collections.Generic;
using CE.Console.Controls;

namespace Serpentina
{
	public class SnakeCollision
	{
		public readonly bool AnyCollision;
		public readonly Snake HeadCollider;
		public readonly Snake PassiveCollider;
	}

	public class SnakeMovement : ISystem, IUpdate
	{
		SnakeCollection _snakes;
		App _app;

		public SnakeMovement (App app)
		{
			_app = app ?? throw new ArgumentNullException (nameof (app));
		}

		public SnakeCollision GetCollision ()
		{
			throw new NotImplementedException ();
		}

		public void Initialize ()
		{
			_snakes = _app.Systems.Get<SnakeCollection> ();
		}

		public void Update ()
		{
			throw new NotImplementedException ();
		}
	}
}