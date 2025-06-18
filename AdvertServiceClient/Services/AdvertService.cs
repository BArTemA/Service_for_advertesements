using System;
using System.Data;
using System.Data.SqlClient;

namespace AdvertServiceClient.Services
{
    public class AdvertService : IDisposable
    {
        private readonly DatabaseService _dbService;

        public AdvertService()
        {
            _dbService = new DatabaseService();
        }

        public DataTable SearchAdvertisements(
            string searchTerm = null,
            int? categoryId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            string city = null,
            string region = null,
            string country = null,
            int? userId = null,
            string status = "Active",
            string sortBy = "PublicationDate",
            string sortDirection = "DESC",
            int pageNumber = 1,
            int pageSize = 20)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@SearchTerm", searchTerm ?? (object)DBNull.Value),
                new SqlParameter("@CategoryID", categoryId ?? (object)DBNull.Value),
                new SqlParameter("@MinPrice", minPrice ?? (object)DBNull.Value),
                new SqlParameter("@MaxPrice", maxPrice ?? (object)DBNull.Value),
                new SqlParameter("@City", city ?? (object)DBNull.Value),
                new SqlParameter("@Region", region ?? (object)DBNull.Value),
                new SqlParameter("@Country", country ?? (object)DBNull.Value),
                new SqlParameter("@UserID", userId ?? (object)DBNull.Value),
                new SqlParameter("@Status", status),
                new SqlParameter("@SortBy", sortBy),
                new SqlParameter("@SortDirection", sortDirection),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@PageSize", pageSize)
            };

            return _dbService.ExecuteStoredProcedure("sp_SearchAdvertisements", parameters);
        }

        public DataTable GetAdvertisementDetails(int advertId, bool incrementViewCount = false)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@AdvertID", advertId),
                new SqlParameter("@IncrementViewCount", incrementViewCount)
            };

            return _dbService.ExecuteStoredProcedure("sp_GetAdvertisementDetails", parameters);
        }

        public int CreateAdvertisement(
            int userId,
            string title,
            string description,
            decimal price,
            int categoryId,
            int? locationId = null,
            DateTime? expirationDate = null)
        {
            var advertIdParam = new SqlParameter("@AdvertID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description),
                new SqlParameter("@Price", price),
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@LocationID", locationId ?? (object)DBNull.Value),
                new SqlParameter("@ExpirationDate", expirationDate ?? (object)DBNull.Value),
                advertIdParam
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_CreateAdvertisement", parameters);

            return (int)advertIdParam.Value;
        }

        public DataTable GetUserAdvertisements(int userId, bool includeInactive = false, int pageNumber = 1, int pageSize = 10)
        {
            var parameters = new SqlParameter[]
            {
        new SqlParameter("@UserID", userId),
        new SqlParameter("@IncludeInactive", includeInactive),
        new SqlParameter("@PageNumber", pageNumber),
        new SqlParameter("@PageSize", pageSize)
            };

            return _dbService.ExecuteStoredProcedure("sp_GetUserAdvertisements", parameters);
        }

        public void DeleteAdvertisement(int advertId, int userId)
        {
            var parameters = new SqlParameter[]
            {
        new SqlParameter("@AdvertID", advertId),
        new SqlParameter("@UserID", userId)
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_DeleteAdvertisement", parameters);
        }

        public void Dispose()
        {
            _dbService.Dispose();
        }
    }
}