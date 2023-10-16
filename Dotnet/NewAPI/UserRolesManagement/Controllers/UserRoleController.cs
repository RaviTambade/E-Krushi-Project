using Transflower.EKrushi.UserRolesManagement.Entities;
using Transflower.EKrushi.UserRolesManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Transflower.EKrushi.UserRolesManagement.Controllers;

[ApiController]
[Route("/api/userroles/")]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _service;

    public UserRoleController(IUserRoleService service)
    {
        _service = service;
    }

  
    [HttpGet("roles/{userId}")]
    public async Task<List<string>> GetRolesByUserId(int userId)
    {
        return await _service.GetRolesByUserId(userId);
    }

    [HttpPost]
    public async Task<bool> Insert(UserRole userRole)
    {
        return await _service.Insert(userRole);
    }

    [HttpGet("userid/{role}")]
    public async Task<List<string>> GetUsersId(string role)
    {
        return await _service.GetUsersId(role);
    }
}
