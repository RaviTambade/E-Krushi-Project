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
    public async Task<IEnumerable<Account>> Accounts()
    {
        List<Account> accounts = await _service.Accounts();
        return accounts;
    }

    [HttpGet]
    [Route("getaccount/{id}")]
    public async Task<Account> GetAccount(int id)
    {
        Account account = await _service.GetAccount(id);
        return account;
    }

    [HttpPost]
    [Route("Insert")]
    public async Task<bool> Insert([FromBody] Account account)
    {
        bool result = await _service.Insert(account);
        return result;
    }

    [HttpPut]
    [Route("Update/{id}")]
    public async Task<bool> Update(int id,[FromBody] Account account)
    {
        Account oldAccount = await _service.GetAccount(id);
        if(oldAccount.Id==0){
            return false;
        }
        account.Id = id;
        bool result = await _service.Update(account);
        return result;
    }
    
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<bool> Delete(int id)
    {
        bool result = await _service.Delete(id);
        return result;
    }

}    