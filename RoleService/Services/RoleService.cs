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

   

    public List<Role> GetAll() =>_repo.GetAll();
    public Role GetById(int id)=>_repo.GetById(id);
    
    public bool InsertRole(Role role)=>_repo.InsertRole(role);

    public bool UpdateRole(Role role)=>_repo.UpdateRole(role);

}