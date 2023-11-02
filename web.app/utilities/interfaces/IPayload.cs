using NetTopologySuite.Index.Quadtree;
using web.app.models;

namespace web.app.utilities.interfaces
{
    public interface IPayload
    {
        Dictionary<string, List<LocationData>> LoadAddressDictionary();
        Quadtree<LocationData> LoadQuadTree();
    }
}
