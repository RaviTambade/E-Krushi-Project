
using E_krushiApp.Models;

namespace E_krushiApp.Repositories.Interface;

 public interface IUserRepository{

   public  List<User> GetAllUsers();

    public User GetById(int id);

    public bool InsertUser(User user);
 }