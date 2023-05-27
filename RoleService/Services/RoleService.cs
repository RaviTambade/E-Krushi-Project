using E_krushiApp.Models;
using E_krushiApp.Repositories.Interface;
using E_krushiApp.Service.Interface;

namespace E_krushiApp.Service;

public class RoleService:IRoleService{

    private readonly IRoleRepository _repo;


    public RoleService (IRoleRepository repo)
    {
        _repo=repo;
    }

   

    public async Task<List<Role>> Roles() => await _repo.Roles();
    public async Task<Role> Role(int id)=>await _repo.Role(id);
    
    public  Task<bool> Insert(Role role)=> _repo.Insert(role);

    public Task<bool> Update(Role role)=>_repo.Update(role);
    public Task<bool> Delete(int id )=>_repo.Delete(id);
}