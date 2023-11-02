using web.app.models;

namespace web.app.utilities.interfaces
{
    public interface ICsvDataProvider
    {
        List<LocationData> GetCachedData();
    }
}
