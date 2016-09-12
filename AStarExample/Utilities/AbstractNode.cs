using AStarExample.Interfaces;

namespace AStarExample.Utilities
{
    public abstract class AbstractNode
    {
        int heuristics, movementCost;
        AbstractNode parentNode;
        readonly Coordinate location;

        protected AbstractNode(Coordinate location)
        {
            this.location = location;
        }

        public int H
        {
            get
            {
                return heuristics;
            }
            set
            {
                if (value > 0)
                {
                    heuristics = value;
                }
            }
        }

        public int G
        {
            get
            {
                return movementCost;
            }
            set
            {
                if (value > 0)
                {
                    movementCost = value;
                }
            }
        }

        public int F
        {
            get
            {
                return G + H;
            }
        }

        public Coordinate Location
        {
            get
            {
                return location;
            }
        }

        public AbstractNode ParentNode
        {
            get
            {
                return parentNode;
            }
            set
            {
                if (value != null && value is INode)
                {
                    parentNode = value;
                }
            }
        }

        public bool IsParseable { get; set; }

        /// <summary>
        /// This method will reset the movement and heuristic costs as well as clearing the parent node.
        /// </summary>
        public void Reset()
        {
            H = 0;
            G = 0;
            parentNode = null;
        }

        /// <summary>
        /// This method will return true if this node is at the same position as <paramref name="nodeToCompare"/>.
        /// </summary>
        /// <param name="nodeToCompare">The node that this node should be compared with.</param>
        /// <returns>True if this node and the <paramref name="nodeToCompare"/> are at the same location.</returns>
        //public bool Equals(AbstractNode nodeToCompare)
        //{
        //    // Compare the location of nodeToCompare and this Node
        //    return (this.location.X == nodeToCompare.Location.X) && (this.location.Y == nodeToCompare.Location.Y);
        //}

        /// <summary>
        /// This method will check if the current node is diagonal to the node specified by <paramref name="nodeToCheck"/>. 
        /// If that is the case, the method will return true otherwise it will return false.
        /// </summary>
        /// <param name="nodeToCheck">The node to check whether or not this node is at a diagonal position.</param>
        /// <returns>True if this node is diagonal to <paramref name="nodeToCheck"/> otherwise it will return false.</returns>
        //public bool IsDiagonal(AbstractNode nodeToCheck)
        //{
        //    int x = Math.Abs(this.location.X - nodeToCheck.Location.X);
        //    int y = Math.Abs(this.location.Y - nodeToCheck.Location.Y);

        //    return (x + y) == 2;
        //}

    }
}
