using AStarExample.Enums;
using AStarExample.Interfaces;
using AStarExample.Utilities;
using System.Collections.Generic;

namespace AStarExample.SimpleAlgorithm
{
    public class PathFinder
    {

        private int width;
        private int height;
        private Node[,] nodes;
        private Node startNode;
        private Node endNode;
        private SearchParameters searchParameters;

        /// <summary>
        /// Creates a new instance of PathFinder
        /// </summary>
        /// <param name="searchParameters"></param>
        public PathFinder(SearchParameters searchParameters)
        {
            this.searchParameters = searchParameters;
            InitializeNodes(searchParameters.Map);
            this.startNode = this.nodes[searchParameters.StartLocation.X, searchParameters.StartLocation.Y];
            this.startNode.State = NodeState.Open;
            this.endNode = this.nodes[searchParameters.EndLocation.X, searchParameters.EndLocation.Y];
        }

        /// <summary>
        /// Attempts to find a path from the start location to the end location based on the supplied SearchParameters
        /// </summary>
        /// <returns>A List of Points representing the path. If no path was found, the returned list is empty.</returns>
        public List<Coordinate> FindPath()
        {
            // The start node is the first node in the 'open' list
            List<Coordinate> path = new List<Coordinate>();
            bool success = Search(startNode);
            if (success)
            {
                // If a path was found, follow the parents from the end node to build a list of locations
                INode node = this.endNode;
                while (node.ParentNode != null)
                {
                    path.Add(node.Location);
                    node = node.ParentNode;
                }

                // Reverse the list so the first node is the starting node and the last node is the ending node
                path.Reverse();
            }

            return path;
        }

        /// <summary>
        /// TODO: Map skal ændres til at have den type som nu passer ind i det man laver! For EcoSystem er det "Life[,] map" i stedet for "bool[,] map"
        /// </summary>
        /// <param name="map"></param>
        private void InitializeNodes(bool[,] map)
        {
            this.width = map.GetLength(0);
            this.height = map.GetLength(1);
            this.nodes = new Node[this.width, this.height];
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    this.nodes[x, y] = new Node(x, y, map[x, y], this.searchParameters.EndLocation);
                }
            }
        }

        /// <summary>
        /// Attempts to find a path to the destination node using <paramref name="currentNode"/> as the starting location
        /// </summary>
        /// <param name="currentNode">The node from which to find a path</param>
        /// <returns>True if a path to the destination has been found, otherwise false</returns>
        private bool Search(Node currentNode)
        {
            // Set the current nodes state as 'Closed' so that it will not be traversed multiple times
            currentNode.State = NodeState.Closed;
            List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);

            // Sort the nodes by their F-value so the shortest possible routes are considered first
            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
            foreach (var nextNode in nextNodes)
            {
                // Check if the end node has been reached
                if (nextNode.Location == this.endNode.Location)
                {
                    return true;
                }
                else
                {
                    // If not, then check the next set of nodes
                    if (Search(nextNode)) // Note: Recursive call back into this method Search(Node)
                    {
                        return true;
                    }
                }
            }

            // Return false if this path leads to a dead end
            return false;
        }

        /// <summary>
        /// Returns any nodes that are adjacent to <paramref name="fromNode"/> and may be considered to form the next step in the path
        /// </summary>
        /// <param name="fromNode">The node from which to return the next possible nodes in the path</param>
        /// <returns>A list of next possible nodes in the path</returns>
        private List<Node> GetAdjacentWalkableNodes(Node fromNode)
        {
            List<Node> walkableNodes = new List<Node>();
            IEnumerable<Coordinate> nextLocations = GetAdjacentLocations(fromNode.Location);

            foreach (var location in nextLocations)
            {
                int x = location.X;
                int y = location.Y;

                // Make sure we are inside the boundaries of the grid
                if (x < 0 || x >= this.width || y < 0 || y >= this.height)
                {
                    continue;
                }

                Node node = this.nodes[x, y];
                // Ignore nodes that can't be parsed
                if (node.IsWalkable == false)
                {
                    continue;
                }

                // Ignore nodes that have already been checked (and closed)
                if (node.State == NodeState.Closed)
                {
                    continue;
                }

                // Nodes that are already open are only added to the list if their G-value are lower going via this route
                if (node.State == NodeState.Open)
                {
                    float traversalCost = Node.GetTraversalCost(node.Location, node.ParentNode.Location);
                    float gTemp = fromNode.G + traversalCost;
                    if (gTemp < node.G)
                    {
                        node.ParentNode = fromNode;
                        walkableNodes.Add(node);
                    }
                }
                else
                {
                    // Untested nodes. Set the parent node and marked its state as 'Open'
                    node.ParentNode = fromNode;
                    node.State = NodeState.Open;
                    walkableNodes.Add(node);
                }

            }

            return walkableNodes;
        }

        /// <summary>
        /// Returns the eight locations that surround the <paramref name="fromLocation"/>
        /// </summary>
        /// <param name="fromLocation">The location from which to return all adjacent points</param>
        /// <returns>The locations as an Enumerable of Points</returns>
        private static IEnumerable<Coordinate> GetAdjacentLocations(Coordinate fromLocation)
        {
            return new Coordinate[]
            {
                new Coordinate(fromLocation.X - 1,   fromLocation.Y-1),
                new Coordinate(fromLocation.X,       fromLocation.Y-1),
                new Coordinate(fromLocation.X + 1,   fromLocation.Y-1),

                new Coordinate(fromLocation.X - 1,   fromLocation.Y),
                new Coordinate(fromLocation.X + 1,   fromLocation.Y),

                new Coordinate(fromLocation.X - 1,   fromLocation.Y+1),
                new Coordinate(fromLocation.X,       fromLocation.Y+1),
                new Coordinate(fromLocation.X + 1,   fromLocation.Y+1)
            };
        }

    }
}
