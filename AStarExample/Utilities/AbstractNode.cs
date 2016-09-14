using AStarExample.Interfaces;

namespace AStarExample.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractNode
    {
        int heuristics, movementCost;
        AbstractNode parentNode;
        readonly Coordinate location;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location">A Coordinate object containing location information about this Node.</param>
        protected AbstractNode(Coordinate location)
        {
            this.location = location;
        }

        /// <summary>
        /// The Heuristics value of this Node
        /// </summary>
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

        /// <summary>
        /// The movement cost of this Node
        /// </summary>
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

        /// <summary>
        /// The total value of this Node.
        /// Found by adding the H and G values.
        /// </summary>
        public int F
        {
            get
            {
                return G + H;
            }
        }

        /// <summary>
        /// The Coordinate specifying the location of this Node
        /// </summary>
        public Coordinate Location
        {
            get
            {
                return location;
            }
        }

        /// <summary>
        /// A reference to the node that represents the parent of this Node
        /// </summary>
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

        /// <summary>
        /// Property indicating if the node is parseable or if it will block any movement through.
        /// </summary>
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

    }
}
