using AdvertServiceClient.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AdvertServiceClient.Services
{
    public class ReviewService : IDisposable
    {
        private readonly DatabaseService _dbService;

        public ReviewService()
        {
            _dbService = new DatabaseService();
        }

        public void AddReview(int reviewerId, int reviewedUserId, decimal rating, string comment = null)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ReviewerID", reviewerId),
                new SqlParameter("@ReviewedUserID", reviewedUserId),
                new SqlParameter("@Rating", rating),
                new SqlParameter("@Comment", comment ?? (object)DBNull.Value)
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_AddReview", parameters);
        }

        public DataTable GetUserReviews(int userId, int pageNumber = 1, int pageSize = 10)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@PageSize", pageSize)
            };

            return _dbService.ExecuteStoredProcedure("sp_GetUserReviews", parameters);
        }

        public DataTable GetReviewsGivenByUser(int userId, int pageNumber = 1, int pageSize = 10)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@PageSize", pageSize)
            };

            return _dbService.ExecuteStoredProcedure("sp_GetReviewsGivenByUser", parameters);
        }

        public void Dispose()
        {
            _dbService.Dispose();
        }
    }
}