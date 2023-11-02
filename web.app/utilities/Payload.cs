
using NetTopologySuite.Geometries;
using web.app.models;
using NetTopologySuite.Index.Quadtree;
using web.app.utilities.interfaces;

namespace web.app.utilities
{
    public class Payload : IPayload
    {
        private List<LocationData> locationData;


        public Payload(ICsvDataProvider dataProvider)
        {
            locationData = dataProvider.GetCachedData();

        }

        public Dictionary<string, List<LocationData>> LoadAddressDictionary()
        {
            Dictionary<string, List<LocationData>> addressDictionary = new Dictionary<string, List<LocationData>>();

            foreach (var record in locationData)
            {
                if (!addressDictionary.ContainsKey(record.Address))
                {
                    addressDictionary[record.Address] = new List<LocationData>();
                }
                addressDictionary[record.Address].Add(record);
            }

            return addressDictionary;
        }

        public Quadtree<LocationData> LoadQuadTree()
        {
            var quadTree = new Quadtree<LocationData>();

            foreach (var data in locationData)
            {
                var point = new Point(data.Longitude, data.Latitude);
                quadTree.Insert(point.EnvelopeInternal, data);
            }

            return quadTree;
        }


    }
}
