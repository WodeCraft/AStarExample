using AStarExample.ConfigurableAlgorithm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AStarExample.Interfaces
{
    public interface IPathFinder
    {
        Task<IEnumerable<INode>> FindBestPathAsync(Grid grid);
        IEnumerable<INode> FindBestPath(Grid grid);
    }
}
