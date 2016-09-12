using AStarExample.Utilities;

namespace AStarExample.Interfaces
{
    public interface IHeuristicCalculator
    {

        void CalculateHeuristics(INode currentNode, INode endNode);

        void CalculateHeuristics(AbstractNode currentNode, AbstractNode endNode);

    }
}
