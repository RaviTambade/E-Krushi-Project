
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
    [Route("AgriDoctors/{id}")]                          //This method gives agri doctor details by id.
    public AgriDoctor GetById(int id)
    {

        AgriDoctor doctor = _srv.GetById(id);

        return doctor;
    }


      [HttpPost]
    [Route("AgriDoctors")]                           //this method is used for insert new agri doctor.
    public bool Insert(AgriDoctor doctor)
    {

        bool status = _srv.Insert(doctor);

        return status;
    }


     [HttpPut]
    [Route("Update")]                                 //this method is used for update agri doctor.
    public bool Update(AgriDoctor doctor)
    {

    bool status = _srv.Update(doctor);

        return status;
    }



      [HttpDelete]
    [Route("Delete/{id}")]
    public bool Delete(int id)                      //this method is used for remove agri doctor .
    {

        bool status = _srv.Delete(id);

        return status;
    }


}
