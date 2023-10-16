using Transflower.EKrushi.UserRolesManagement.Entities;

namespace Transflower.EKrushi.UserRolesManagement.Repositories.Interfaces;

public interface IUserRoleRepository
{
    Task<List<string>> GetUsersId(string role);
    Task<List<string>> GetRolesByUserId(int userId);
    Task<bool> Insert(UserRole userRole);
}
