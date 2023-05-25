
using E_krushiApp.Models;
using E_krushiApp.Services.Interface.IAgriDoctorsService;
using Microsoft.AspNetCore.Mvc;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AgriDoctorsController : ControllerBase
{


    private readonly IAgriDoctorsService _srv;

    public AgriDoctorsController(IAgriDoctorsService srv)
    {
        _srv = srv;
    }


    [HttpGet]
    [Route("AgriDoctors")]                            
    public List<AgriDoctor> GetAll()                 //This method gives Agri doctor List.
    {

        List<AgriDoctor> doctors = _srv.GetAll();

        return doctors;
    }


    [HttpGet]
    [Route("AgriDoctor/{id}")]                          //This method gives agri doctor details by id.
    public AgriDoctor GetById(int id)
    {

        AgriDoctor doctor = _srv.GetById(id);

        return doctor;
    }


      [HttpPost]
    [Route("AgriDoctor")]                           //this method is used for insert new agri doctor.
    public bool InsertDoctor(AgriDoctor doctor)
    {

        bool status = _srv.InsertDoctor(doctor);

        return status;
    }


     [HttpPut]
    [Route("AgriDoctor")]                                 //this method is used for update agri doctor.
    public bool UpdateDoctor(AgriDoctor doctor)
    {

    bool status = _srv.UpdateDoctor(doctor);

        return status;
    }



      [HttpDelete]
    [Route("DeleteDoctor/{id}")]
    public bool DeleteDoctor(int id)                      //this method is used for remove agri doctor .
    {

        bool status = _srv.DeleteDoctor(id);

        return status;
    }


}
