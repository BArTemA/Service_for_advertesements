using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdvertServiceClient
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AdvertServiceDB"].ConnectionString;
        }

        public DataTable ExecuteQuery(string sqlQuery)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sqlQuery, connection))
            {
                var dataTable = new DataTable();
                var adapter = new SqlDataAdapter(command);

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error executing query: {ex.Message}", ex);
                }

                return dataTable;
            }
        }

        public DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                var dataTable = new DataTable();
                var adapter = new SqlDataAdapter(command);

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error executing stored procedure {procedureName}: {ex.Message}", ex);
                }

                return dataTable;
            }
        }

        public int ExecuteStoredProcedureNonQuery(string procedureName, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error executing stored procedure {procedureName}: {ex.Message}", ex);
                }
            }
        }

        public object ExecuteStoredProcedureScalar(string procedureName, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error executing stored procedure {procedureName}: {ex.Message}", ex);
                }
            }
        }
    }
}