using AdvertServiceClient.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AdvertServiceClient.Services
{
    public class UserService : IDisposable
    {
        private readonly DatabaseService _dbService;

        public UserService()
        {
            _dbService = new DatabaseService();
        }

        public User GetUserDetails(int userId)
        {
            var parameters = new SqlParameter[]
            {
        new SqlParameter("@UserID", userId)
            };

            var table = _dbService.ExecuteStoredProcedure("sp_GetUserDetails", parameters);
            if (table.Rows.Count == 0) return null;

            var row = table.Rows[0];

            var user = new User
            {
                UserID = userId,
                Username = row["Username"].ToString(),
                Email = row["Email"].ToString(),
                RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]),
                LastLoginDate = row["LastLoginDate"] != DBNull.Value ? Convert.ToDateTime(row["LastLoginDate"]) : (DateTime?)null,
                IsModerator = Convert.ToBoolean(row["IsModerator"]),
                Rating = row["Rating"] != DBNull.Value ? Convert.ToDecimal(row["Rating"]) : (decimal?)null,
                Phone = row["Phone"]?.ToString(),
                Location = new Location
                {
                    City = row["City"]?.ToString(),
                    Region = row["Region"]?.ToString(),
                    Country = row["Country"]?.ToString()
                }
            };

            return user;
        }

        public void UpdateUserProfile(int userId, string email, string phone, int? locationId, byte[] profilePicture)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@Email", email ?? (object)DBNull.Value),
                new SqlParameter("@Phone", phone ?? (object)DBNull.Value),
                new SqlParameter("@LocationID", locationId ?? (object)DBNull.Value),
                new SqlParameter("@ProfilePicture", profilePicture ?? (object)DBNull.Value)
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_UpdateUserProfile", parameters);
        }

        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@OldPassword", oldPassword),
                new SqlParameter("@NewPassword", newPassword)
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_ChangePassword", parameters);
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

        public void Dispose()
        {
            _dbService.Dispose();
        }
    }
}