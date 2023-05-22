using E_krushiApp.Models;
using E_krushiApp.Repositories.Interface;
using E_krushiApp.Services.Interface;
namespace E_krushiApp.Services;
public class UserService : IUserService

{
    private readonly IUserRepository _repo ;
   
    public UserService(IUserRepository repo){
        _repo=repo;
    }
    public List<User> GetAllUsers()=>_repo.GetAllUsers();

    public User GetById(int id)=>_repo.GetById(id);

    public bool Register(User user)=>_repo.Register(user);

    public bool UpdateUser(User user)=>_repo.UpdateUser(user);

    public bool DeleteUser(int id)=>_repo.DeleteUser(id);

    public AuthenticateResponse Authenticate(AuthenticateRequest request)=>_repo.Authenticate(request);
        
    public bool ValidateUser(Credential user)=>_repo.ValidateUser(user);
    }

