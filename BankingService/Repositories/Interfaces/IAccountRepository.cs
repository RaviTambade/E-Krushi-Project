using BankingService.Models;

namespace BankingService.Repositories.Interfaces
{
    public interface IAccountRepository{

        List<Account> Accounts();
        Account GetAccount(int id);
        bool Insert(Account account);
        bool Update(Account account);
        bool Delete(int id);
    }
}