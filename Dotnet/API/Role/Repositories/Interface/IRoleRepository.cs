using E_krushiApp.Models;
namespace E_krushiApp.Repositories.Interface;

public interface IRoleRepository
{


    public Task<List<Role>> GetAll();

    public Task<Role> GetById(int id);
    public Task<bool> Insert(Role role);

    public Task<bool> Update(Role role);

    public Task<bool> Delete(int id);

    public Task<List<string>> GetRolesOfUser(int id);
}