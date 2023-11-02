using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.app.models;
using web.app.utilities.interfaces;

namespace web.test
{
    public class MockCsvDataProvider : ICsvDataProvider
    {
        public List<LocationData> GetCachedData()
        {
            // Provide test data as needed for your tests
            return new List<LocationData>
            {
                new LocationData
                {
                    Address = "123 Main St",
                    City = "Cityville",
                    State = "ST",
                    Zip = "12345",
                    Latitude = 40.1234,
                    Longitude = -75.6789
                },
                new LocationData
                {
                    Address = "456 Elm St",
                    City = "Townsville",
                    State = "TS",
                    Zip = "54321",
                    Latitude = 35.4321,
                    Longitude = -80.9876
                },
                new LocationData
                {
                    Address = "789 Oak Ave",
                    City = "Villagetown",
                    State = "VT",
                    Zip = "98765",
                    Latitude = 42.8765,
                    Longitude = -70.1234
                },
                new LocationData
                {
                    Address = "321 Cedar Rd",
                    City = "Hamletville",
                    State = "HT",
                    Zip = "65432",
                    Latitude = 38.9876,
                    Longitude = -85.4321
                },
                new LocationData
                {
                    Address = "567 Birch Ln",
                    City = "Villageville",
                    State = "VL",
                    Zip = "23456",
                    Latitude = 36.5432,
                    Longitude = -90.8765
                },
                // Add more test data as required
            };
        }

        // Implement other methods of ICsvDataProvider if needed for your tests
    }

}
