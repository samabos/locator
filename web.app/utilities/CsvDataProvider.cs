using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using web.app.models;
using web.app.utilities.interfaces;

namespace web.app.utilities
{
    public class CsvDataProvider : ICsvDataProvider
    {
        private List<LocationData> cachedData;
        private readonly string csvFilePath;

        public CsvDataProvider(string csvFilePath)
        {
            this.csvFilePath = csvFilePath;
            cachedData = LoadLocationData();
        }

        public List<LocationData> GetCachedData()
        {
            return cachedData;
        }

        private List<LocationData> LoadLocationData()
        {
            List<LocationData> locationData = new List<LocationData>();

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                locationData = csv.GetRecords<LocationData>().ToList();
            }

        return locationData;
    }


}
}
