using BankingService.Models;

namespace BankingService.Repositories.Interfaces
{
    public interface ITransactionRepository{

        List<Transaction> Transactions();
        Transaction GetTransaction(int id);
        bool Insert(Transaction transaction);
        bool Update(Transaction transaction);
        bool Delete(int id);
    }
}