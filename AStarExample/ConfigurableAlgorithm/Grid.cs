using System.Collections.Generic;

namespace AStarExample.ConfigurableAlgorithm
{
    /// <summary>
    /// This class is representing the Grid that make up the game world. It is used for the pathfinding within the gameworld
    /// 
    /// NOTE: This is basically the same as the SearchParameters class in the SimpleAlgorithm!
    /// </summary>
    public class Grid
    {
        // Note: By using 'private readonly' you ensure thread-safety
        public readonly IEnumerable<Node> Nodes;

        public Grid(IEnumerable<Node> nodes)
        {
            Nodes = nodes;
        }

        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        public void Reset()
        {
            StartNode = null;
            EndNode = null;
        }

    }
}
