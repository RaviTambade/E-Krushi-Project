using BankingService.Models;

namespace BankingService.Repositories.Interfaces
{
    public interface IAccountRepository{

        List<Account> GetAllAccounts();
        Account GetAccount(int id);
        bool InsertAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(int id);
    }
}