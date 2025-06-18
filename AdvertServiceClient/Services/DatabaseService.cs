using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdvertServiceClient.Services
{
    public class DatabaseService : IDisposable
    {
        private SqlConnection _connection;

        public DatabaseService()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdvertServiceConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(procedureName, _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                var dataTable = new DataTable();
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
                return dataTable;
            }
        }

        public int ExecuteStoredProcedureNonQuery(string procedureName, SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(procedureName, _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteStoredProcedureScalar(string procedureName, SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(procedureName, _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                return command.ExecuteScalar();
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}