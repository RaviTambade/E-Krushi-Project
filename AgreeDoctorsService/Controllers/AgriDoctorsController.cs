
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
    [Route("GetAllAgriDoctor")]
    public List<AgriDoctor> GetAll()
    {

        List<AgriDoctor> doctors = _srv.GetAll();

        return doctors;
    }


    [HttpGet]
    [Route("getbyid/{id}")]
    public AgriDoctor GetById(int id)
    {

        AgriDoctor doctor = _srv.GetById(id);

        return doctor;
    }


      [HttpPost]
    [Route("InsertDoctor")]
    public bool InsertDoctor(AgriDoctor doctor)
    {

        bool status = _srv.InsertDoctor(doctor);

        return status;
    }


     [HttpPut]
    [Route("UpdateDoctor")]
    public bool UpdateDoctor(AgriDoctor doctor)
    {

    bool status = _srv.UpdateDoctor(doctor);

        return status;
    }



      [HttpDelete]
    [Route("DeleteDoctor/{id}")]
    public bool DeleteDoctor(int id)
    {

        bool status = _srv.DeleteDoctor(id);

        return status;
    }


}
