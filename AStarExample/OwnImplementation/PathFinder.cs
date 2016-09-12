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

        private readonly List<Node> OpenList = new List<Node>();

        private readonly List<Node> ClosedList = new List<Node>();

        public PathFinder(IHeuristicCalculator heuristicCalculator)
        {
            this.heuristicCalculator = heuristicCalculator;
        }

        public List<Node> FindBestPath(PathFinderParameters searchParameters)
        {
            Reset();
            CalculateHeuristics(searchParameters.Nodes, searchParameters.EndNode);

            // Step 1:
            // Step 1.1: Add CurrentNode to ClosedList. First run-through the CurrentNode is searchParameters.StartNode
            //          How to make sure the two nodes can be compared?
            Node currentNode = searchParameters.StartNode;
            ClosedList.Add(currentNode);
            // Step 1.2: As long as there is a CurrentNode and the CurrentNode is not the same as the searchParameters.EndNode
            // TODO This is not updating the values for the nodes in searchParameters.Nodes, but instead a different list of nodes
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

                // Step 3: Add surrounding Nodes to OpenList, if they aren't there already
                //OpenList.AddRange(surroundingNodes);

                // Step 4: 
                // Step 4.1: Find the Node with the lowest F in OpenList
                Node lowestF = FindNextNode();
                // Step 4.2: Set CurrentNode = NodeWithLowestF
                currentNode = lowestF;
                // Step 4.3: If CurrentNode = searchParameters.EndNode then we are done!
                // Step 4.4: Else update OpenList and ClosedList
                OpenList.Remove(currentNode);
                ClosedList.Add(currentNode);

                // Repeat from Step 1
            }

            //List<Node> bestPath = FetchBestPath(searchParameters);

            return ClosedList; // bestPath;
        }

        private void Reset()
        {
            OpenList.Clear();
            ClosedList.Clear();
        }

        private List<Node> FindSurroundingNodes(IEnumerable<Node> allNodes, Node currentNode)
        {
            // Step 1.3: Find surrounding nodes for CurrentNode which are not in the ClosedList
            List<Node> surroundingNodes = allNodes.Where(n => n.Location.IsCoordinateNextTo(currentNode.Location)).ToList<Node>();

            // INFO This solution could be very slow since all nodes are looped through
            //List<Node> surroundingNodes = new List<Node>();
            //foreach (Node n in allNodes)
            //{
            //    if (n.Location.IsCoordinateNextTo(currentNode.Location))
            //    {
            //        surroundingNodes.Add(n);
            //    }
            //}

            return surroundingNodes;
        }

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

        private Node FindNextNode()
        {
            // Step 4.1: Find the Node with the lowest F in OpenList
            //          A null value is possible
            return OpenList.OrderBy(node => node.F).First();
        }

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


        private void CalculateHeuristics(IEnumerable<Node> nodes, Node endNode)
        {

            foreach (Node n in nodes)
            {
                heuristicCalculator.CalculateHeuristics(n, endNode);
            }

        }

    }
}
