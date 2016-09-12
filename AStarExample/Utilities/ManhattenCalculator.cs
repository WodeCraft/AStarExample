using AStarExample.Interfaces;
using System;

namespace AStarExample.Utilities
{
    public class ManhattenCalculator : IHeuristicCalculator
    {
        public void CalculateHeuristics(AbstractNode currentNode, AbstractNode endNode)
        {
            int xDifference = Math.Abs(currentNode.Location.X - endNode.Location.X);
            int yDifference = Math.Abs(currentNode.Location.Y - endNode.Location.Y);

            currentNode.H = 10 * (xDifference + yDifference);
        }

        public void CalculateHeuristics(INode currentNode, INode endNode)
        {
            int xDifference = Math.Abs(currentNode.Location.X - endNode.Location.X);
            int yDifference = Math.Abs(currentNode.Location.Y - endNode.Location.Y);

            currentNode.H = 10 * (xDifference + yDifference);
        }
    }
}
