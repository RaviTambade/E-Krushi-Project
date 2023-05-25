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

    public List<Transaction> Transactions() => _repo.Transactions();
    public Transaction GetTransaction(int id) => _repo.GetTransaction(id);
    public bool Insert(Transaction transaction) => _repo.Insert(transaction);
    public bool Update(Transaction transaction) => _repo.Update(transaction);
    public bool Delete(int id) => _repo.Delete(id);

}