using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.app.utilities;

namespace web.test
{
    public class HaversineUnitTest
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)]  // Test when both coordinates are the same
        [InlineData(52.5200, 13.4050, 48.8566, 2.3522, 877.5)]  // Berlin to Paris (km)
        [InlineData(37.7749, -122.4194, 34.0522, -118.2437, 559.1)]  // San Francisco to Los Angeles (km)
        public void CalculateDistance_ReturnsExpectedResult(double lat1, double lon1, double lat2, double lon2, double expectedDistance)
        {
            var haversine = new Haversine();
            double distance = haversine.CalculateDistance(lat1, lon1, lat2, lon2);
            Assert.Equal(expectedDistance, distance, 1);
        }

    }
}
