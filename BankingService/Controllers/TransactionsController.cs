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
    [Route("getalltransactions")]
    public IEnumerable<Transaction> GetAllTransactions()
    {
        List<Transaction> transactions = _service.GetAllTransactions();
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
    [Route("Inserttransaction")]
    public bool InsertTransaction([FromBody] Transaction transaction)
    {
        bool result = _service.InsertTransaction(transaction);
        return result;
    }

    [HttpPut]
    [Route("UpdateTransaction/{id}")]
    public bool UpdateTransaction(int id,[FromBody] Transaction transaction)
    {
        Transaction oldTransaction = _service.GetTransaction(id);
        if(oldTransaction.TransactionId==0){
            return false;
        }
        transaction.TransactionId = id;
        bool result = _service.UpdateTransaction(transaction);
        return result;
    }
    [HttpDelete]
    [Route("DeleteTransaction/{id}")]
    public bool DeleteTransaction(int id)
    {
        bool result = _service.DeleteTransaction(id);
        return result;
    }

}    