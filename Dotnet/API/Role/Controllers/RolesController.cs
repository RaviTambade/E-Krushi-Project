using E_krushiApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using E_krushiApp.Models;
using E_krushiApp.Service.Interface;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("/api/roles")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _srv;

    public RolesController(IRoleService srv)
    {
        _srv = srv;
    }
   
    public async Task<List<Role>> GetAll()
    {

        List<Role> roles = await _srv.GetAll();

        return roles;
    }


    [HttpGet("{id}")]
    public  async Task<Role> GetById(int id)
    {
        Role role = await  _srv.GetById(id);

        return role;
    }

    public async  Task<bool> Insert(Role role)
    {

        bool status = await  _srv.Insert(role);


        return status;
    }

    public async  Task<bool> Update([FromBody] Role role)
    {
        bool status = await _srv.Update(role);

        return status;
    }


    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {

        bool status =await _srv.Delete(id);
        return status;
    }

    [HttpGet("user/{id}")]
    public  async Task<List<string>> GetRolesOfUser(int id)
    {
        List<string> roles = await  _srv.GetRolesOfUser(id);

        return roles;
    }
}
