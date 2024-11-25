using ServicesLab1.Models;

namespace ServicesLab1.Repositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int transactionID);
        void UpdaTransaction(Transaction transaction);
    }
}