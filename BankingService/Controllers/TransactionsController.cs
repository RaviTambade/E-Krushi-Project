using BankingService.Models;
using BankingService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Krushi.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _service;

    public TransactionsController(ITransactionService service)
    {
        _service = service;
    }


    [HttpGet]
    [Route("transactions")]
    public IEnumerable<Transaction> Transactions()
    {
        List<Transaction> transactions = _service.Transactions();
        return transactions;
    }

    [HttpGet]
    [Route("gettransaction/{id}")]
    public Transaction GetTransaction(int id)
    {
        Transaction transaction = _service.GetTransaction(id);
        return transaction;
    }

    [HttpPost]
    [Route("Insert")]
    public bool Insert([FromBody] Transaction transaction)
    {
        bool result = _service.Insert(transaction);
        return result;
    }

    [HttpPut]
    [Route("Update/{id}")]
    public bool Update(int id,[FromBody] Transaction transaction)
    {
        Transaction oldTransaction = _service.GetTransaction(id);
        if(oldTransaction.Id==0){
            return false;
        }
        transaction.Id = id;
        bool result = _service.Update(transaction);
        return result;
    }
    [HttpDelete]
    [Route("Delete/{id}")]
    public bool Delete(int id)
    {
        bool result = _service.Delete(id);
        return result;
    }

}    