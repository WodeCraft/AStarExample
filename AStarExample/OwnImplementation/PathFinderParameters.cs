using System.Collections.Generic;

namespace AStarExample.OwnImplementation
{
    public class PathFinderParameters
    {

        public readonly IEnumerable<Node> Nodes;

        public readonly Node StartNode;

        public readonly Node EndNode;

        public PathFinderParameters(IEnumerable<Node> nodes, Node startNode, Node endNode)
        {
            Nodes = nodes;
            StartNode = startNode;
            EndNode = endNode;
        }
    }
}
