using NetTopologySuite.Geometries;
using NetTopologySuite.Index.Quadtree;
using web.app.models;
using web.app.utilities.interfaces;

namespace web.app.utilities
{
    public class Query : IQuery
    {
        private readonly ILogger<Query> logger;
        private readonly Dictionary<string, List<LocationData>> addressDictionary;
        private readonly Quadtree<LocationData> quadTree;
        private readonly IHaversine haversine;
        public Query(ILogger<Query> logger, IPayload payload, IHaversine haversine)
        {
            this.logger = logger;
            addressDictionary = payload.LoadAddressDictionary();
            quadTree = payload.LoadQuadTree();
            this.haversine = haversine;
        }

        /// <summary>
        /// Performing a nearest location search using the quadtree and haversine formular
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public List<LocationData> GetNearestLocations(double lat, double lon)
        {
            List<LocationData> nearestLocations = new List<LocationData>();
            try
            {
                var searchEnvelope = new Envelope(lon, lon, lat, lat);
                nearestLocations = quadTree.Query(searchEnvelope).Cast<LocationData>()
                    .Where(w => w.Latitude != lat && w.Longitude != lon)
                    .OrderBy(o => haversine.CalculateDistance(lat, lon, o.Latitude, o.Longitude))
                    .Take(10)
                    .ToList();
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred in GetNearestLocations: {ErrorMessage}", ex.Message);
            }
            return nearestLocations;
        }

        /// <summary>
        /// Performing a case-insensitive partial match on the address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public List<LocationData> SearchByAddress(string address) {
            List<LocationData> searchResults = new List<LocationData>();
            try
            {
                //throw new Exception("testing");
                searchResults = addressDictionary
                    .Where(x => x.Key.Contains(address, StringComparison.OrdinalIgnoreCase))
                    .SelectMany(kv => kv.Value)
                    .ToList();
            }
            catch (Exception ex) {
                logger.LogError(ex, "An error occurred in SearchByAddress: {ErrorMessage}", ex.Message);
            }
            return searchResults;
        }
    }
}
