using AuthenticationService.Models;

namespace AuthenticationService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<List<User>> Users();

        Task<User> User(int id);

        Task<bool> Register(User user);

        Task<bool> Update(User user);
        Task<bool> Delete(int id);
    
        Task<bool> Validate(AuthenticateRequest user);
    }
}