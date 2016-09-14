using System.Collections.Generic;

namespace AStarExample.OwnImplementation
{
    public class PathFinderParameters
    {
        /// <summary>
        /// List of Node objects which should be checked while finding a path.
        /// </summary>
        public readonly IEnumerable<Node> Nodes;

        /// <summary>
        /// The start Node for finding that path.
        /// </summary>
        public readonly Node StartNode;

        /// <summary>
        /// The end Node to which a path should be found.
        /// </summary>
        public readonly Node EndNode;

        public PathFinderParameters(IEnumerable<Node> nodes, Node startNode, Node endNode)
        {
            Nodes = nodes;
            StartNode = startNode;
            EndNode = endNode;
        }
    }
}
