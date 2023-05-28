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
    public async Task<IEnumerable<Transaction>> Transactions()
    {
        List<Transaction> transactions =await  _service.Transactions();
        return transactions;
    }

    [HttpGet]
    [Route("transaction/{id}")]
    public async Task<Transaction> GetTransaction(int id)
    {
        Transaction transaction =await  _service.GetTransaction(id);
        return transaction;
    }

    [HttpPost]
    [Route("Insert")]
    public async Task<bool> Insert([FromBody] Transaction transaction)
    {
        bool result =await  _service.Insert(transaction);
        return result;
    }

    [HttpPut]
    [Route("Update/{id}")]
    public async Task<bool> Update(int id,[FromBody] Transaction transaction)
    {
        Transaction oldTransaction =await _service.GetTransaction(id);
        if(oldTransaction.Id==0){
            return false;
        }
        transaction.Id = id;
        bool result =await _service.Update(transaction);
        return result;
    }
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<bool> Delete(int id)
    {
        bool result =await _service.Delete(id);
        return result;
    }

}    