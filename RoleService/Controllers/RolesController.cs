using E_krushiApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using E_krushiApp.Models;
using E_krushiApp.Service.Interface;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{


    private readonly IRoleService _srv;

    public RolesController(IRoleService srv)
    {
        _srv = srv;
    }


    [HttpGet("roles")]
   
    public List<Role> Roles()
    {

        List<Role> roles = _srv.Roles();

        return roles;
    }


    [HttpGet("role/{id}")]
    public Role Role(int id)
    {
        Role role = _srv.Role(id);

        return role;
    }


    [HttpPost("Insert")]
    public bool Insert(Role role)
    {

        bool status = _srv.Insert(role);


        return status;
    }

    [HttpPut("Update/{id}")]
    public bool Update(int id, [FromBody] Role role)
    {
        Role oldRole = _srv.Role(id);
        if (oldRole.Id == 0)
        {

            return false;
        }
        role.Id = id;
        bool status = _srv.Update(role);

        return status;
    }


    [HttpDelete("delete/{id}")]
    public bool Delete(int id)
    {

        bool status = _srv.Delete(id);
        return status;
    }
}
