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

   

    public List<Role> Roles() =>_repo.Roles();
    public Role Role(int id)=>_repo.Role(id);
    
    public bool Insert(Role role)=>_repo.Insert(role);

    public bool Update(Role role)=>_repo.Update(role);
    public bool Delete(int id )=>_repo.Delete(id);
}