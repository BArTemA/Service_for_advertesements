using System;
using System.Data;
using System.Data.SqlClient;

namespace AdvertServiceClient.Services
{
    public class LocationService : IDisposable
    {
        private readonly DatabaseService _dbService;

        public LocationService()
        {
            _dbService = new DatabaseService();
        }

        public DataTable GetAllLocations()
        {
            return _dbService.ExecuteQuery(
                "SELECT LocationID, City, Region, Country FROM Location ORDER BY Country, Region, City");
        }

        public DataTable SearchLocations(string searchTerm)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@SearchTerm", searchTerm)
            };

            return _dbService.ExecuteStoredProcedure("sp_SearchLocations", parameters);
        }

        public int AddLocation(string city, string region, string country, string zipCode = null)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@City", city),
                new SqlParameter("@Region", region),
                new SqlParameter("@Country", country),
                new SqlParameter("@ZipCode", string.IsNullOrEmpty(zipCode) ? (object)DBNull.Value : zipCode),
                new SqlParameter("@LocationID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_AddLocation", parameters);
            return (int)parameters[4].Value;
        }

        public void Dispose()
        {
            _dbService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}