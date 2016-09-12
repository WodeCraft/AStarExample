using System;
using System.Collections.Generic;

namespace AStarExample.ConfigurableAlgorithm
{
    public sealed class AStarPathFinderDetails : EventArgs
    {
        // Note: By using 'private readonly' you ensure thread-safety
        private readonly Node newClosedNode;
        public Node NewClosedNode
        {
            get { return newClosedNode; }
        }

        // Note: By using 'private readonly' you ensure thread-safety
        private readonly List<Node> openNodes;
        public List<Node> OpenNodes
        {
            get { return openNodes; }
        }

        public AStarPathFinderDetails(List<Node> openNodes, Node newClosedNode)
        {
            this.openNodes = openNodes;
            this.newClosedNode = newClosedNode;
        }

    }
}
