using web.app.models;

namespace web.app.utilities.interfaces
{
    public interface IQuery
    {
        List<LocationData> GetNearestLocations(double lat, double lon);
        List<LocationData> SearchByAddress(string address);
    }
}
