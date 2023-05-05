using BankingService.Models;

namespace BankingService.Repositories.Interfaces
{
    public interface ITransactionRepository{

        List<Transaction> GetAllTransactions();
        Transaction GetTransaction(int id);
        bool InsertTransaction(Transaction transaction);
        bool UpdateTransaction(Transaction transaction);
        bool DeleteTransaction(int id);
    }
}