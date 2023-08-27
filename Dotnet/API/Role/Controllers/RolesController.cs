using Transflower.EKrushi.Role.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.Role.Models;
using Transflower.EKrushi.Role.Service.Interface;
namespace Transflower.EKrushi.Role.Controllers;

[ApiController]
[Route("/api/roles")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService service)
    {
        _roleService = service;
    }

    public async Task<List<UserRole>> GetAll()
    {

        List<UserRole> roles = await _roleService.GetAll();

        return roles;
    }


    [HttpGet("{id}")]
    public async Task<UserRole> GetById(int id)
    {
        UserRole role = await _roleService.GetById(id);

        return role;
    }



    [HttpPost]
    public async Task<bool> Insert(UserRole role)
    {

        bool status = await _roleService.Insert(role);


        return status;
    }


    [HttpPut]
    public async Task<bool> Update([FromBody] UserRole role)
    {
        bool status = await _roleService.Update(role);

        return status;
    }


    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {

        bool status = await _roleService.Delete(id);
        return status;
    }

    [HttpGet("user/{id}")]
    public async Task<List<string>> GetRolesOfUser(int id)
    {
        List<string> roles = await _roleService.GetRolesOfUser(id);

        return roles;
    }
}
