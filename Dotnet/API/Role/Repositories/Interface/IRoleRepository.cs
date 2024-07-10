using Transflower.EKrushi.Role.Models;
namespace Transflower.EKrushi.Role.Repositories.Interface;

public interface IRoleRepository
{
    public Task<List<UserRole>> GetAll();

    public Task<UserRole> GetById(int id);
    public Task<bool> Insert(UserRole role);

    public Task<bool> Update(UserRole role);

    public Task<bool> Delete(int id);

    public Task<List<string>> GetRolesOfUser(int id);
}