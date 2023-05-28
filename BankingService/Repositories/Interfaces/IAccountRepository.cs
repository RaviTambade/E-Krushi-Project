using BankingService.Models;

namespace BankingService.Repositories.Interfaces
{
    public interface IAccountRepository{

        Task<List<Account>> Accounts();
        Task<Account> GetAccount(int id);
        Task<bool> Insert(Account account);
        Task<bool> Update(Account account);
        Task<bool> Delete(int id);
    }
}