using System;

namespace AStarExample.Utilities
{
    /// <summary>
    /// This class contains information about a single coordinate in the game world
    /// </summary>
    public class Coordinate
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        /// Creates a new instance of a Coordinate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// This method will return true if <paramref name="other"/> is the same coordinate as this.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Coordinate other)
        {
            return other.X == X && other.Y == Y;
        }

        /// <summary>
        /// This method will return true if the <paramref name="other"/> coordinate is next to this coordinate.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsCoordinateNextTo(Coordinate other)
        {
            //if (Equals(other))
            //{
            //    return false;
            //}

            //return Math.Abs(other.X - X) <= 1 && Math.Abs(other.Y - Y) <= 1;
            return IsCoordinateDiagonal(other) || IsCoordinateHorizontalOrVertical(other);
        }

        /// <summary>
        /// This method will return true if the <paramref name="other"/> coordinate is diagonal to this coordinate.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsCoordinateDiagonal(Coordinate other)
        {
            if (Equals(other))
            {
                return false;
            }

            return Math.Abs(other.X - X) == 1 && Math.Abs(other.Y - Y) == 1;
        }

        /// <summary>
        /// This method will return true if the <paramref name="other"/> coordinate is either horizonal or vertical to this coordinate.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsCoordinateHorizontalOrVertical(Coordinate other)
        {
            if (Equals(other))
            {
                return false;
            }

            return (Math.Abs(other.X - X) + Math.Abs(other.Y - Y)) == 1;
        }

    }
}
