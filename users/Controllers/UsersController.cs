
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
    [Route("getall")]
    public IEnumerable<User> GetAll()
    {
        
    List<User> users = _service.GetAllUsers();

       return users;
       
    }

 [HttpGet]
 [Route("getbyid/{id}")]
    public User GetById(int id)
    {
        User user = _service.GetById(id);


        return user;
    }

    [HttpPost]
    [Route("register")]
       public bool Register(User user)
    {
        bool status = _service.Register(user);


        return status;
    }

   [HttpPut]
   [Route("updateUser")]

   public bool UpdateUser(User user){
    bool status = _service.UpdateUser(user);

    return status;
   }


   [HttpDelete]
   [Route("DeleteUser/{id}")]
   public bool DeleteUser(int id){
    bool status =_service.DeleteUser(id);

    return status;
   }

   [HttpPost]
   [Route("ValidateUser")]
   public bool ValidateUser(Credential user){
    bool status =_service.ValidateUser(user);
    if(status==true){
        Console.WriteLine("user is valid");
    }
    return status;
   }
}
