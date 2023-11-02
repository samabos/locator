namespace web.app.utilities.interfaces
{
    public interface IHaversine
    {
        double CalculateDistance(double lat1, double lon1, double lat2, double lon2);
    }
}
