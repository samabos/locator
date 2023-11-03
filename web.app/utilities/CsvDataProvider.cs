using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using web.app.models;
using web.app.utilities.interfaces;

namespace web.app.utilities
{
    public class CsvDataProvider : ICsvDataProvider
    {
        private readonly ILogger<CsvDataProvider> logger;
        private List<LocationData> cachedData;
        private readonly string csvFilePath;

        public CsvDataProvider(string csvFilePath, ILogger<CsvDataProvider> logger)
        {
            this.csvFilePath = csvFilePath;
            cachedData = LoadLocationData();
            this.logger = logger;
        }

        public List<LocationData> GetCachedData()
        {
            return cachedData;
        }

        private List<LocationData> LoadLocationData()
        {
            List<LocationData> locationData = new List<LocationData>();
            try
            {
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    locationData = csv.GetRecords<LocationData>().ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in LoadLocationData: {ErrorMessage}", ex.Message);
            }
            return locationData;
    }


}
}
