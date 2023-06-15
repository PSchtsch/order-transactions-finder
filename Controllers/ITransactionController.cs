namespace TransactionsFinder.Controllers
{
    internal interface ITransactionController
    {
        object GetAllRelatedTransactions(string entryNumber);
    }
}
