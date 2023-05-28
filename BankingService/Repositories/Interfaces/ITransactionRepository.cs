using BankingService.Models;

namespace BankingService.Repositories.Interfaces
{
    public interface ITransactionRepository{

        Task<List<Transaction>> Transactions();
        Task<Transaction> GetTransaction(int id);
        Task<bool> Insert(Transaction transaction);
        Task<bool> Update(Transaction transaction);
        Task<bool> Delete(int id);
    }
}