using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdvertServiceClient.Services
{
    public class CategoryService : IDisposable
    {
        private readonly DatabaseService _dbService;

        public CategoryService()
        {
            _dbService = new DatabaseService();
        }

        public DataTable GetAllCategories()
        {
            
            var query = "SELECT CategoryID, Name, Description FROM Category ORDER BY Name";

            // (пустой массив, так как параметров нет)
            var parameters = Array.Empty<SqlParameter>();

            return _dbService.ExecuteStoredProcedure("sp_GetAllCategories", parameters);
        }

        public int AddCategory(string name, string description = null)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description),
                new SqlParameter("@CategoryID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            _dbService.ExecuteStoredProcedureNonQuery("sp_AddCategory", parameters);
            return (int)parameters[2].Value;
        }

        public int UpdateCategory(int categoryId, string name, string description = null)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description)
            };

            return _dbService.ExecuteStoredProcedureNonQuery("sp_UpdateCategory", parameters);
        }

        public int DeleteCategory(int categoryId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryID", categoryId)
            };

            return _dbService.ExecuteStoredProcedureNonQuery("sp_DeleteCategory", parameters);
        }

        public void Dispose()
        {
            _dbService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}