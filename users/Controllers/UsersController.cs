
using E_krushiApp.Models;
using E_krushiApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace users.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
   
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<User> GetAll()
    {
       var user = _service.GetAllUsers();

       return user;
       
    }

   
}
