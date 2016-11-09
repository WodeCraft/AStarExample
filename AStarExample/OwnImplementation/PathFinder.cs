using AStarExample.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AStarExample.OwnImplementation
{
    public class PathFinder
    {
        int horizontalCost = 10;
        int diagonalCost = 14;

        private IHeuristicCalculator heuristicCalculator;

        // List of Nodes that still needs to be checked
        private readonly List<Node> OpenList = new List<Node>();

        // List of Nodes that have already been checked
        private readonly List<Node> ClosedList = new List<Node>();

        public PathFinder(IHeuristicCalculator heuristicCalculator)
        {
            this.heuristicCalculator = heuristicCalculator;
        }

        /// <summary>
        /// This method will step through all Nodes in the "world" to find the best 
        /// path between searchParameters.StartNode and searchParameters.EndNode.
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns>A List object containing the different Node objects representing the best path.</returns>
        public List<Node> FindBestPath(PathFinderParameters searchParameters)
        {
            Reset();
            // Start out by calculating the heuristics values of all nodes.
            CalculateHeuristics(searchParameters.Nodes, searchParameters.EndNode);

            // Step 1:
            // Step 1.1: Add CurrentNode to ClosedList. First run-through the CurrentNode is searchParameters.StartNode
            Node currentNode = searchParameters.StartNode;
            ClosedList.Add(currentNode);
            // Step 1.2: As long as there is a CurrentNode and the CurrentNode is not the same as the searchParameters.EndNode
            while (currentNode != null && !currentNode.Location.Equals(searchParameters.EndNode.Location))
            {
                // Step 1.3: Find surrounding nodes for CurrentNode which are not in the ClosedList
                List<Node> surroundingNodes = FindSurroundingNodes(searchParameters.Nodes, currentNode);

                // Step 2: 
                // Step 2.1: Calculate G for the Nodes surrounding CurrentNode
                foreach (Node n in surroundingNodes)
                {
                    // Step 2.2: Check if any Nodes need to have their G recalculated
                    bool recalculated = CalculateMovementCost(n, currentNode);
                    // Step 2.3: Update n.ParentNode = currentNode if G has been recalculated
                    if (recalculated)
                    {
                        n.ParentNode = currentNode;
                        // Step 3: Add surrounding Nodes to OpenList, if they aren't there already
                        OpenList.Add(n);
                    }
                }

                // Step 4: 
                // Step 4.1: Find the Node with the lowest F in OpenList
                Node lowestF = FindNextNode();
                // Step 4.2: Set CurrentNode = NodeWithLowestF
                currentNode = lowestF;
                // Step 4.3: Else update OpenList and ClosedList
                OpenList.Remove(currentNode);
                ClosedList.Add(currentNode);

                // Repeat from Step 1
            }

            return ClosedList;
        }

        /// <summary>
        /// Used for resetting the lists of Open and Closed Nodes.
        /// </summary>
        private void Reset()
        {
            OpenList.Clear();
            ClosedList.Clear();
        }

        /// <summary>
        /// This method will find all the nodes in <paramref name="allNodes"/> that are surrounding nodes of <paramref name="currentNode"/> .
        /// </summary>
        /// <param name="allNodes"></param>
        /// <param name="currentNode"></param>
        /// <returns>Returns a list of Nodes that are all surrounding <paramref name="currentNode"/>.</returns>
        private List<Node> FindSurroundingNodes(IEnumerable<Node> allNodes, Node currentNode)
        {
            // Step 1.3: Find surrounding nodes for CurrentNode which are not in the ClosedList
            List<Node> surroundingNodes = allNodes.Where(n => n.Location.IsCoordinateNextTo(currentNode.Location)).ToList<Node>();
            return surroundingNodes;
        }

        /// <summary>
        /// This method will calculate the movementcost of <paramref name="n"/> based on <paramref name="potentialParent"/>.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="potentialParent"></param>
        /// <returns>Returns a boolean value indicating whether or not the movement cost of <paramref name="n"/> has been recalculated.</returns>
        private bool CalculateMovementCost(Node n, Node potentialParent)
        {
            // Step 2.2: Check if any Nodes need to have their G recalculated
            //          If G has been recalculated, then return true. Else return false
            //          Horizontal/Vertical => n.ParentNode.G + 10
            //          Diagonal            => n.ParentNode.G + 14
            int newMovementCost = n.Location.IsCoordinateDiagonal(potentialParent.Location) ? potentialParent.G + diagonalCost : potentialParent.G + horizontalCost;
            if (n.G == 0 || newMovementCost <= n.G)
            {
                n.G = newMovementCost;
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method will find the next Node with the lowest F value from the class property OpenList.
        /// It is possible that a null value will be found.
        /// </summary>
        /// <returns>Returns a Node object with the lowest F value.</returns>
        private Node FindNextNode()
        {
            // Step 4.1: Find the Node with the lowest F in OpenList
            //          A null value is possible
            return OpenList.OrderBy(node => node.F).First();
        }

        /// <summary>
        /// NB: Currently not used! The ClosedList is now containing the best path.
        /// </summary>
        /// <param name="parameters">A PathFinderParameters object containing the </param>
        /// <returns>Returns a list of Node objects representing the best path from a start node to the end node. These are specified in the <paramref name="parameters"/>.</returns>
        private List<Node> FetchBestPath(PathFinderParameters parameters)
        {
            List<Node> returnList = new List<Node>() { parameters.EndNode };

            bool startNodeFound = false;

            Node lastNode = parameters.EndNode;

            while (startNodeFound == false)
            {
                lastNode = (Node)lastNode.ParentNode;

                returnList.Add(lastNode);

                //if (lastNode.Equals(parameters.StartNode))
                if (lastNode.Location.Equals(parameters.StartNode.Location))
                {
                    startNodeFound = true;
                }
            }

            return returnList;
        }

        /// <summary>
        /// Method that makes sure all <paramref name="nodes"/> will get their 
        /// heuristics value calculated based on their location relative to 
        /// the <paramref name="endNode"/>.
        /// 
        /// The actual calculation of the heuristics value is being done by the 
        /// CalculateHeuristics()-method in the implementation of the IHeuristicsCalculator 
        /// that has been specified when the constructor was called.
        /// </summary>
        /// <param name="nodes">An IEnumerable collection of Node that will get their heuristics calculated.</param>
        /// <param name="endNode">A Node object representing the end node.</param>
        private void CalculateHeuristics(IEnumerable<Node> nodes, Node endNode)
        {

            foreach (Node n in nodes)
            {
                heuristicCalculator.CalculateHeuristics(n, endNode);
            }

        }

    }
}
