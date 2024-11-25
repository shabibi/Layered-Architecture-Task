using ServicesLab1.Models;

namespace ServicesLab1.Services
{
    public interface ITransactionService
    {
        void AddTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int transactionID);
        void UpdaTransaction(Transaction transaction);
    }
}