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

    public async Task<List<Account>> Accounts() => await _repo.Accounts();
    public async Task<Account> GetAccount(int id) => await _repo.GetAccount(id);
    public async Task<bool> Insert(Account account) => await _repo.Insert(account);
    public async Task<bool> Update(Account account) => await _repo.Update(account);
    public async Task<bool> Delete(int id) => await _repo.Delete(id);

}