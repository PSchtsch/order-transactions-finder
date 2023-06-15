using System.Data;
using System.Data.SqlClient;
using TransactionsFinder.Models;

namespace TransactionsFinder.Controllers
{
    internal class TransactionController : ITransactionController
    {
        private readonly ISqlQueryRunner _db = new ApplicationContext();
        
        public object GetAllRelatedTransactions(string entryNumber)
        {
            string queryString = 
                "SELECT " +
                    "WorkOrder.WorkOrderNumber as WorkOrder, " +
                    "WOTransaction.EntryNumber as Entry, " +
                    "WOTransactionItem.Description, " +
                    "FORMAT(WOTransactionItem.Amount,'c', 'en-us') as Amount " +
                "FROM WorkOrder " +
                "JOIN WOTransaction " +
                "ON WorkOrder.ID = WOTransaction.WorkOrderID " +
                "JOIN WOTransactionItem " +
                "ON WOTransaction.ID = WOTransactionItem.WOTransactionID " +
                "WHERE WOTransaction.EntryNumber = @entryNumber " +
                "ORDER BY EntryNumber, Description";

            SqlCommand command = new SqlCommand(queryString);

            //try to avoid sql-injection
            SqlParameter entryNumberParameter = new SqlParameter("@entryNumber", SqlDbType.VarChar);
            entryNumberParameter.Value = entryNumber;
            command.Parameters.Add(entryNumberParameter);

            DataTable queryResult = _db.ExecuteQuery(command);

            return queryResult;
        }
    }
}
