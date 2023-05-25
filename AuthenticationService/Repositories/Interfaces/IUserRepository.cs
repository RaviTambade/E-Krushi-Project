using AuthenticationService.Models;

namespace AuthenticationService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        Task<bool> Register(User user);

        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    
        Task<bool> ValidateUser(AuthenticateRequest user);
    }
}