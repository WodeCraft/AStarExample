using AStarExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AStarExample.ConfigurableAlgorithm
{
    public class AStarPathFinder : IPathFinder, IIteratable<AStarPathFinderDetails>
    {
        //private const int DiagonalMoveCost = 2;
        //private const int SimpleMoveCost = 1;
        private readonly List<Node> closedNodes = new List<Node>();
        private readonly IHeuristicCalculator heuristicCalculator;
        private readonly List<Node> openNodes = new List<Node>();


        public AStarPathFinder(IHeuristicCalculator heuristicCalculator)
        {
            this.heuristicCalculator = heuristicCalculator;
        }

        public event EventHandler<AStarPathFinderDetails> IterationComplete;

        public Task<IEnumerable<INode>> FindBestPathAsync(Grid grid)
        {
            try
            {
                return Task.Factory.StartNew(() => FindBestPath(grid));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<INode> FindBestPath(Grid grid)
        {
            if (grid.EndNode == null || grid.StartNode == null)
            {
                return new List<Node>();
            }

            Reset();

            // TODO Lav en hulans masse beregninger og gennemløb for at finde den bedste path!
            //      Calculate heuristics on all the Nodes in the Grid

            throw new NotImplementedException();
        }

        public void Reset()
        {
            openNodes.Clear();
            closedNodes.Clear();
        }


        #region Static methods
        public static void Reparent(Node parent, Node child)
        {
            child.ParentNode = parent;
        }

        private static IEnumerable<Node> GetSurroundingNodes(Grid grid, Node node)
        {
            return grid.Nodes.Where(possibleSurroundingNode => possibleSurroundingNode.Location.IsCoordinateNextTo(node.Location));
        }
        #endregion
    }
}
