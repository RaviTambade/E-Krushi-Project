using E_krushiApp.Models;
namespace E_krushiApp.Repositories.Interface;

public interface IRoleRepository{


    public List<Role> Roles();

    public Role Role(int id);

     public bool Insert(Role role);

     public bool Update(Role role);

     public bool Delete(int id);
}