using System.Data;
using System.Data.SqlClient;

namespace TransactionsFinder.Models
{
    internal interface ISqlQueryRunner
    {
        DataTable ExecuteQuery(SqlCommand command);
    }
}
