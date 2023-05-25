using BankingService.Models;
using BankingService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Krushi.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountsController(IAccountService service)
    {
        _service = service;
    }


    [HttpGet]
    [Route("accounts")]
    public IEnumerable<Account> Accounts()
    {
        List<Account> accounts = _service.Accounts();
        return accounts;
    }

    [HttpGet]
    [Route("getaccount/{id}")]
    public Account GetAccount(int id)
    {
        Account account = _service.GetAccount(id);
        return account;
    }

    [HttpPost]
    [Route("Insert")]
    public bool Insert([FromBody] Account account)
    {
        bool result = _service.Insert(account);
        return result;
    }

    [HttpPut]
    [Route("Update/{id}")]
    public bool Update(int id,[FromBody] Account account)
    {
        Account oldAccount = _service.GetAccount(id);
        if(oldAccount.Id==0){
            return false;
        }
        account.Id = id;
        bool result = _service.Update(account);
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