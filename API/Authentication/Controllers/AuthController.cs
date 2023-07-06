using AuthenticationService.Models;
using AuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _svc;
        public AuthController(IUserService svc)
        {
            _svc = svc;

        }

        [HttpPost("authenticate")] 
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            var user =await _svc.Authenticate(request);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        

        [HttpGet("users")]  
        public async Task<IEnumerable<User>> Users()
        {
            var users = _svc.Users();
            return await users;
        }
    

        [HttpGet]
        [Route("user/{id}")]
        public async Task<User> User(int id)
        {
        User user = await _svc.User(id);
        return user;
        }

        [HttpPost]
        [Route("register")]
        public async Task<bool> Register(User user)
        {
            bool status = await _svc.Register(user);
            return status;
        }

        [HttpPut]
        [Route("update")]

        public async Task<bool> Update(User user){
        bool status = await _svc.Update(user);
        return status;
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> Delete(int id){
            bool status =await _svc.Delete(id);
            return status;
        }

        [HttpPost]
        [Route("Validate")]
        public async Task<bool> Validate(AuthenticateRequest user){
            bool status =await _svc.Validate(user);
            if(status==true){
                Console.WriteLine("user is valid");
            }
            return status;
        }
    }
}