using AStarExample.Interfaces;
using AStarExample.Utilities;

namespace AStarExample.ConfigurableAlgorithm
{
    public class Node : INode
    {
        float heuristics, movementCost;
        INode parentNode;
        readonly Coordinate location;

        public Node(Coordinate location)
        {
            this.location = location;
        }

        public float F
        {
            get
            {
                return G + H;
            }
        }

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

        public Coordinate Location
        {
            get
            {
                return location;
            }

        }

        public INode ParentNode
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


        public bool IsWall { get; set; }

        public bool IsNew
        {
            get { return G == 0; }
        }

        public void Reset()
        {
            H = 0; // Heuristic - Distance to end node
            G = 0; // MoveCost - Distance from start node
            parentNode = null;
        }

    }
}
