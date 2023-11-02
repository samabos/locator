using NetTopologySuite.Geometries;
using NetTopologySuite.Index.Quadtree;
using web.app.models;
using web.app.utilities.interfaces;

namespace web.app.utilities
{
    public class Query : IQuery
    {
        private readonly Dictionary<string, List<LocationData>> addressDictionary;
        private readonly Quadtree<LocationData> quadTree;
        private readonly IHaversine haversine;
        public Query(IPayload payload, IHaversine haversine)
        {
            addressDictionary = payload.LoadAddressDictionary();
            quadTree = payload.LoadQuadTree();
            this.haversine = haversine;
        }

        public List<LocationData> GetNearestLocations(double lat, double lon)
        {
            //var payload = new Payload(); // Create an instance of your Payload class
            //var quadTree = LoadQuadTree(); // Load the QuadTree

            var searchEnvelope = new Envelope(lon, lon, lat, lat);
            var nearestLocations = quadTree.Query(searchEnvelope).Cast<LocationData>()
                .Where(w => w.Latitude != lat && w.Longitude != lon)
                .OrderBy(o => haversine.CalculateDistance(lat, lon, o.Latitude, o.Longitude))
                .Take(10)
                .ToList();

            return nearestLocations;
        }

        public List<LocationData> SearchByAddress(string address) {
            //var addressDictionary = payload.LoadAddressDictionary();
            // Performing a case-insensitive partial match on the address
            var searchResults = addressDictionary
                .Where(x => x.Key.Contains(address, StringComparison.OrdinalIgnoreCase))
                .SelectMany(kv => kv.Value)
                .ToList();

            return searchResults;
        }
    }
}
