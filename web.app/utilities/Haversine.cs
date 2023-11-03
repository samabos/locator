using web.app.utilities.interfaces;

namespace web.app.utilities
{
    public class Haversine : IHaversine
    {
        /// <summary>
        ///  Method to calculate the distance between two sets of coordinates
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lon1"></param>
        /// <param name="lat2"></param>
        /// <param name="lon2"></param>
        /// <returns></returns>
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double earthRadius = 6371; // Radius of the Earth in kilometers

            // Convert latitude and longitude from degrees to radians
            double lat1Rad = Math.PI * lat1 / 180;
            double lon1Rad = Math.PI * lon1 / 180;
            double lat2Rad = Math.PI * lat2 / 180;
            double lon2Rad = Math.PI * lon2 / 180;

            // Haversine formula
            double dLat = lat2Rad - lat1Rad;
            double dLon = lon2Rad - lon1Rad;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1Rad) * Math.Cos(lat2Rad) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = earthRadius * c;

            return distance;
        }
    }
}
