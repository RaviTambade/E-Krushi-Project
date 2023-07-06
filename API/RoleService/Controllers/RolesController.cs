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
   
    public async Task<List<Role>> Roles()
    {

        List<Role> roles = await _srv.Roles();

        return roles;
    }


    [HttpGet("role/{id}")]
    public  async Task<Role> Role(int id)
    {
        Role role = await  _srv.Role(id);

        return role;
    }


    [HttpPost("Insert")]
    public async  Task<bool> Insert(Role role)
    {

        bool status = await  _srv.Insert(role);


        return status;
    }

    [HttpPut("Update/{id}")]
    public async  Task<bool> Update(int id, [FromBody] Role role)
    {
        Role oldRole = await _srv.Role(id);
        if (oldRole.Id == 0)
        {

            return false;
        }
        role.Id = id;
        bool status = await _srv.Update(role);

        return status;
    }


    [HttpDelete("delete/{id}")]
    public async Task<bool> Delete(int id)
    {

        bool status =await _srv.Delete(id);
        return status;
    }
}
