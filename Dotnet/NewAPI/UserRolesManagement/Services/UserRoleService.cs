using Transflower.EKrushi.UserRolesManagement.Services.Interfaces;
using Transflower.EKrushi.UserRolesManagement.Repositories.Interfaces;
using Transflower.EKrushi.UserRolesManagement.Entities;

namespace Transflower.EKrushi.UserRolesManagement.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _repository;

    public UserRoleService(IUserRoleRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<string>> GetRolesByUserId(int userId)
    {
        return await _repository.GetRolesByUserId(userId);
    }

    public async Task<List<string>> GetUsersId(string role)
    {
        return await _repository.GetUsersId(role);
    }

    public async Task<bool> Insert(UserRole userRole)
    {
        return await _repository.Insert(userRole);
    }

    public async Task<bool> Delete(int userRoleId)
    {
        return await _repository.Delete(userRoleId);
    }
}
