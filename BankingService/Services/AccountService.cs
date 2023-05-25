using BankingService.Repositories.Interfaces;
using BankingService.Service.Interfaces;
using BankingService.Models;

namespace BankingService.Repositories;

public class AccountService : IAccountService{

    private readonly IAccountRepository _repo;

    public AccountService(IAccountRepository repo)
    {
        _repo = repo;
    }

    public List<Account> Accounts() => _repo.Accounts();
    public Account GetAccount(int id) => _repo.GetAccount(id);
    public bool Insert(Account account) => _repo.Insert(account);
    public bool Update(Account account) => _repo.Update(account);
    public bool Delete(int id) => _repo.Delete(id);

}