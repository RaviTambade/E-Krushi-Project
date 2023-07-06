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
        public async Task<List<User>> Users()
        {
            return await _userrepo.Users();
        }

        public async Task<User> User(int id)
        {
            return await _userrepo.User(id);
        }

        public async Task<bool> Register(User user)
        {
            return await _userrepo.Register(user);
        }

        public async Task<bool> Update(User user)
        {
            return await _userrepo.Update(user);
        }

        public async Task<bool> Delete(int id)
        {
            return await _userrepo.Delete(id);  
        }
        public async Task<bool> Validate(AuthenticateRequest user)
        {
            return await _userrepo.Validate(user);
        }
    }
}