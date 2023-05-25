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

        

        [HttpGet("getall")]  
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = _svc.GetAll();
            return await users;
        }
    

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<User> GetById(int id)
        {
        User user = await _svc.GetById(id);
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
        [Route("updateUser")]

        public async Task<bool> UpdateUser(User user){
        bool status = await _svc.UpdateUser(user);
        return status;
        }


        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<bool> DeleteUser(int id){
            bool status =await _svc.DeleteUser(id);
            return status;
        }

        [HttpPost]
        [Route("ValidateUser")]
        public async Task<bool> ValidateUser(AuthenticateRequest user){
            bool status =await _svc.ValidateUser(user);
            if(status==true){
                Console.WriteLine("user is valid");
            }
            return status;
        }
    }
}