using AuthenticationService.Models;
using AuthenticationService.Repositories.Interfaces;
using AuthenticationService.Services.Interfaces;

namespace AuthenticationService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepo;
        public UserService(IUserRepository userrepo)
        {
            _userrepo = userrepo;
        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            return await _userrepo.Authenticate(request);
        }
        public async Task<List<User>> GetAll()
        {
            return await _userrepo.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userrepo.GetById(id);
        }

        public async Task<bool> Register(User user)
        {
            return await _userrepo.Register(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _userrepo.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userrepo.DeleteUser(id);  
        }
        public async Task<bool> ValidateUser(AuthenticateRequest user)
        {
            return await _userrepo.ValidateUser(user);
        }
    }
}