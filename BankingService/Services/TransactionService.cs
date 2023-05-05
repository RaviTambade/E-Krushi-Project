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

    public List<Transaction> GetAllTransactions() => _repo.GetAllTransactions();
    public Transaction GetTransaction(int id) => _repo.GetTransaction(id);
    public bool InsertTransaction(Transaction transaction) => _repo.InsertTransaction(transaction);
    public bool UpdateTransaction(Transaction transaction) => _repo.UpdateTransaction(transaction);
    public bool DeleteTransaction(int id) => _repo.DeleteTransaction(id);

}