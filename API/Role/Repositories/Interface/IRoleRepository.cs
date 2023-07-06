using E_krushiApp.Models;
namespace E_krushiApp.Repositories.Interface;

public interface IRoleRepository
{


    public Task<List<Role>> Roles();

    public Task<Role> Role(int id);
    public Task<bool> Insert(Role role);

    public Task<bool> Update(Role role);

    public Task<bool> Delete(int id);
}