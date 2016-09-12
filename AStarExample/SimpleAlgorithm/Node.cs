using AStarExample.Enums;
using AStarExample.Interfaces;
using AStarExample.Utilities;
using System;

namespace AStarExample.SimpleAlgorithm
{
    /// <summary>
    /// Represents a single Node on a grid when searching for a path between two points
    /// </summary>
    public class Node : INode
    {
        float heuristics, movementCost;
        readonly Coordinate location;


        /// <summary>
        /// The location of this node inside the grid
        /// </summary>
        public Coordinate Location
        {
            get
            {
                return location;
            }
        }

        /// <summary>
        /// G-value is the movement cost for start to here
        /// </summary>
        public float G
        {
            get
            {
                return movementCost;
            }
            set
            {
                if (value >= 0)
                {
                    movementCost = value;
                }
            }
        }

        /// <summary>
        /// H-value is the heuristics value of this node.
        /// The estimated cost from here to the end location,
        /// </summary>
        public float H
        {
            get
            {
                return heuristics;
            }
            set
            {
                if (value >= 0)
                {
                    heuristics = value;
                }
            }
        }

        /// <summary>
        /// F-value is the estimated total cost (F = G + H)
        /// </summary>
        public float F
        {
            get
            {
                return this.H + this.G;
            }
        }

        /// <summary>
        /// Specifying whether the node is Open, Closed or Untested by the PathFinder
        /// </summary>
        public NodeState State { get; set; }

        private INode parentNode;
        /// <summary>
        /// Gets or sets the parent node. The start node's parent is always null
        /// </summary>
        public INode ParentNode
        {
            get { return this.parentNode; }
            set
            {
                this.parentNode = value;
                // When setting the parent node also calculate the traversal cost from the start node to here (the G-value)
                this.G = this.parentNode.G + GetTraversalCost(this.Location, this.parentNode.Location);
            }
        }

        /// <summary>
        /// This specifies whether this node is traversable or not
        /// </summary>
        public bool IsWalkable { get; set; } = true;

        /// <summary>
        /// Creates a new instance of Node.
        /// </summary>
        /// <param name="x">The node's location along the X axis</param>
        /// <param name="y">The node's location along the Y axis</param>
        /// <param name="isWalkable">True if the node can be traversed, false if the node is a wall</param>
        /// <param name="endLocation">The location of the destination node</param>
        public Node(int x, int y, bool isWalkable, Coordinate endLocation)
        {
            this.location = new Coordinate(x, y);
            this.State = NodeState.Untested;
            this.IsWalkable = isWalkable;
            this.H = GetTraversalCost(this.Location, endLocation);
            this.G = 0;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}: {2}", this.Location.X, this.Location.Y, this.State);
        }

        /// <summary>
        /// The distance between two points by Euclidean calculation
        /// </summary>
        /// <param name="location"></param>
        /// <param name="otherLocation"></param>
        /// <returns></returns>
        internal static float GetTraversalCost(Coordinate location, Coordinate otherLocation)
        {
            // TODO Could this be done by using the "normal" values?
            float deltaX = otherLocation.X - location.X;
            float deltaY = otherLocation.Y - location.Y;
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
