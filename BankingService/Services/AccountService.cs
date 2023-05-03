using AccountService.Repositories.Interfaces;
using AccountService.Service.Interfaces;
using AccountService.Models;

namespace BankingService.Repositories;

public class AccountService : IAccountService{

    private readonly IAccountRepository _repo;

    public AccountService(IAccountRepository repo)
    {
        _repo = repo;
    }

    public List<Account> GetAllAccounts() => _repo.GetAllAccounts();
    public Account GetAccount(int id) => _repo.GetAccount(id);
    public bool InsertAccount(Account account) => _repo.InsertAccount(account);
    public bool UpdateAccount(Account account) => _repo.UpdateAccount(account);
    public bool DeleteAccount(int id) => _repo.DeleteAccount(id);

}