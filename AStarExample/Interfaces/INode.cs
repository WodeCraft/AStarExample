using AStarExample.Utilities;

namespace AStarExample.Interfaces
{
    public interface INode
    {

        Coordinate Location { get; }

        float G { get; set; }

        float H { get; set; }

        float F { get; }

        INode ParentNode { get; set; }

    }
}
