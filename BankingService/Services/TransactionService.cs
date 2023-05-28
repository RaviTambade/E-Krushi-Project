using BankingService.Repositories.Interfaces;
using BankingService.Service.Interfaces;
using BankingService.Models;

namespace BankingService.Repositories;

public class TransactionService : ITransactionService{

    private readonly ITransactionRepository _repo;

    public TransactionService(ITransactionRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Transaction>> Transactions() =>await _repo.Transactions();
    public async  Task<Transaction> GetTransaction(int id) =>await  _repo.GetTransaction(id);
    public async Task<bool> Insert(Transaction transaction) =>await  _repo.Insert(transaction);
    public async Task<bool> Update(Transaction transaction) =>await  _repo.Update(transaction);
    public async Task<bool> Delete(int id) =>await  _repo.Delete(id);

}