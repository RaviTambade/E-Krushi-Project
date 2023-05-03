
using E_krushiApp.Models;
using E_krushiApp.Services.Interface.IAgriDoctorsService;
using Microsoft.AspNetCore.Mvc;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AgriDoctorsController : ControllerBase
{
    

    private readonly IAgriDoctorsService   _srv; 

    public AgriDoctorsController(IAgriDoctorsService srv)
    {
        _srv = srv;
    }


 [HttpGet]
 [Route("getall")]
    public List<AgriDoctor> GetAll(){

        List<AgriDoctor> doctors = _srv.GetAll();

        return doctors;
    }


   
}
