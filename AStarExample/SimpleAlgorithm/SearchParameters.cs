using AStarExample.Utilities;

namespace AStarExample.SimpleAlgorithm
{
    public class SearchParameters
    {
        public Coordinate StartLocation { get; set; }

        public Coordinate EndLocation { get; set; }

        // NOTE: The type should be changed to represent the correct type used in the application
        public bool[,] Map { get; set; }

        public SearchParameters(Coordinate startLocation, Coordinate endLocation, bool[,] map)
        {
            this.StartLocation = startLocation;
            this.EndLocation = endLocation;
            this.Map = map;
        }
    }
}
