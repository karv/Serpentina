using System;
using System.Linq;
using CE;
using CE.Color;

namespace Serpentina
{
	/// <summary>
	/// A snake (player)
	/// </summary>
	public class Snake
	{
		ColoredChar _headChar;
		ColoredChar _bodyChar;
		MoveDir _currentHeadDir;
		SnakeTail _bodyPoints;
		TimeSpan _advanceTime;
		TimeSpan _accumulatedAdvTime;
		bool _isAlive = true;

		/// <summary>
		/// Gets or sets the time required to advance a square.
		/// </summary>
		public TimeSpan AdvanceTime { get => _advanceTime; set => _advanceTime = value; }
		/// <summary>
		/// Gets or sets the accumulated time for movement.
		/// </summary>
		public TimeSpan AccumulatedAdvTime { get => _accumulatedAdvTime; set => _accumulatedAdvTime = value; }
		/// <summary>
		/// Gets the array of body points.
		/// </summary>
		public SnakeTail BodyPoints { get => _bodyPoints; set => _bodyPoints = value; }
		/// <summary>
		/// Gets or sets the current movement direction.
		/// </summary>
		public MoveDir CurrentHeadDir { get => _currentHeadDir; set => _currentHeadDir = value; }
		/// <summary>
		/// Gets or sets the body char for drawing.
		/// </summary>
		public ColoredChar BodyChar { get => _bodyChar; set => _bodyChar = value; }
		/// <summary>
		/// Gets or sets the head char for drawing
		/// </summary>
		public ColoredChar HeadChar { get => _headChar; set => _headChar = value; }
		/// <summary>
		/// Gets the location of the head.
		/// </summary>
		public Point HeadLocation { get { return _bodyPoints[0]; } }
		/// <summary>
		/// Gets the location of the head after the next movement.
		/// </summary>
		public Point OverheadLocation { get { return HeadLocation + _currentHeadDir.ToPoint (); } }
		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Serpentina.Snake"/> is alive.
		/// </summary>
		public bool IsAlive { get => _isAlive; }
		/// <summary>
		/// Gets the length.
		/// </summary>
		public int Length { get { return _bodyPoints.Count; } }

		/// <summary>
		/// Accumulates the specified time it <see cref="AccumulatedAdvTime"/>
		/// </summary>
		/// <returns><c>true</c>, if shoudl execute move. <c>false</c> otherwise.</returns>
		/// <param name="time">Time.</param>
		public bool PassTime (TimeSpan time)
		{
			AccumulatedAdvTime += time;
			return AccumulatedAdvTime >= AdvanceTime;
		}

		/// <summary>
		/// Determines whether a specified point is inside this snake.
		/// </summary>
		public bool ContainsPoint (Point p)
		{
			return _bodyPoints.Contains (p);
		}

		/// <summary>
		/// Mark this snake as dead.
		/// </summary>
		public void Die ()
		{
			_isAlive = false;
		}
	}
}