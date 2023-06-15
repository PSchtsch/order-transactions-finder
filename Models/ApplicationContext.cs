using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TransactionsFinder.Models
{
    internal class ApplicationContext : ISqlQueryRunner
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Sus"].ConnectionString;
        private DataSet _dataSet = null;

        public DataTable ExecuteQuery(SqlCommand sqlCommand)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                sqlCommand.Connection = connection;

                var adapter = new SqlDataAdapter(sqlCommand);
                _dataSet = new DataSet();
                adapter.Fill(_dataSet);
            }

            return _dataSet.Tables[0];
        }
    }
}
