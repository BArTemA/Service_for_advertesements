using AdvertServiceClient.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AdvertServiceClient.Services
{
    public class AuthService : IDisposable
    {
        private readonly DatabaseService _dbService;

        public AuthService()
        {
            _dbService = new DatabaseService();
        }

        public User Authenticate(string usernameOrEmail, string password)
        {
            var isAuthenticatedParam = new SqlParameter("@IsAuthenticated", SqlDbType.Bit) { Direction = ParameterDirection.Output };
            var userIdParam = new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var isModeratorParam = new SqlParameter("@IsModerator", SqlDbType.Bit) { Direction = ParameterDirection.Output };

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@UsernameOrEmail", usernameOrEmail),
                new SqlParameter("@Password", password),
                isAuthenticatedParam,
                userIdParam,
                isModeratorParam
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_AuthenticateUser", parameters);

            bool isAuthenticated = (bool)isAuthenticatedParam.Value;
            if (!isAuthenticated)
                return null;

            return new User
            {
                UserID = (int)userIdParam.Value,
                IsModerator = (bool)isModeratorParam.Value
            };
        }

        public int RegisterUser(string username, string email, string password, string phone = null, int? locationId = null)
        {
            var userIdParam = new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@Phone", phone ?? (object)DBNull.Value),
                new SqlParameter("@LocationID", locationId ?? (object)DBNull.Value),
                userIdParam
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_RegisterUser", parameters);

            return (int)userIdParam.Value;
        }

        public void Dispose()
        {
            _dbService.Dispose();
        }
    }
}