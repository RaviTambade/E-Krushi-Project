using AccountService.Models;
using AccountService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }


    [HttpGet]
    [Route("getallaccount")]
    public IEnumerable<Account> GetAllAccounts()
    {
        List<Account> accounts = _service.GetAllAccounts();
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
    [Route("Insertaccount")]
    public bool InsertAccount([FromBody] Account account)
    {
        bool result = _service.InsertAccount(account);
        return result;
    }

    [HttpPut]
    [Route("UpdateAccount/{id}")]
    public bool UpdateAccount(int id,[FromBody] Account account)
    {
        Account oldAccount = _service.GetAccount(id);
        if(oldAccount.AccountId==0){
            return false;
        }
        account.AccountId = id;
        bool result = _service.UpdateAccount(account);
        return result;
    }
    [HttpDelete]
    [Route("DeleteAccount/{id}")]
    public bool DeleteAccount(int id)
    {
        bool result = _service.DeleteAccount(id);
        return result;
    }

}    