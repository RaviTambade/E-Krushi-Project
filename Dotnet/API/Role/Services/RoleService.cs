using Transflower.EKrushi.Role.Models;
using Transflower.EKrushi.Role.Repositories.Interface;
using Transflower.EKrushi.Role.Service.Interface;

namespace Transflower.EKrushi.Role.Service;

public class RoleService:IRoleService{

    private readonly IRoleRepository _repository;


    public RoleService (IRoleRepository repository)
    {
        _repository=repository;
    }

   

    public async Task<List<UserRole>> GetAll() => await _repository.GetAll();
    public async Task<UserRole> GetById(int id)=>await _repository.GetById(id);
    
    public  Task<bool> Insert(UserRole role)=> _repository.Insert(role);

    public Task<bool> Update(UserRole role)=> _repository.Update(role);
    public Task<bool> Delete(int id )=> _repository.Delete(id);
     public Task<List<string>> GetRolesOfUser(int id )=> _repository.GetRolesOfUser(id);
}