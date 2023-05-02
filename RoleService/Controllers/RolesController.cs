using E_krushiApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using E_krushiApp.Models;
using E_krushiApp.Service.Interface;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{
    

    private readonly IRoleService  _srv; 

    public RolesController(IRoleService srv)
    {
        _srv = srv;
    }


 [HttpGet]
 [Route("getall")]
    public List<Role> GetAll(){

        List<Role> roles = _srv.GetAll();

        return roles;
    }


    [HttpGet]
    [Route("getById/{id}")]

    public Role GetById(int id){
        Role role = _srv.GetById(id);

        return role;
    }


    [HttpPost]
    [Route("Insert")]

    public bool InsertRole(Role role){
   
        bool status = _srv.InsertRole(role);


        return status;
    }

    [HttpPut]
    [Route("Update")]

    public bool UpdateRole(Role role){
        bool status=_srv.UpdateRole(role);

        return status;
    }
}
