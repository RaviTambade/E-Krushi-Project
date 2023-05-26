
using E_krushiApp.Models;
using E_krushiApp.Services.Interface.IAgriDoctorsService;
using Microsoft.AspNetCore.Mvc;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ConsultingController : ControllerBase
{
    private readonly IConsultingService _srv;

    public ConsultingController(IConsultingService srv)
    {
        _srv = srv;
    }


    //Get list of all subject matter experts available in Krishi Seva
    //http://localhost:5645/api/Consulting/sme/

    //Get details of Subject matter Expert
    //http://localhost:5645/api/Consulting/sme/{smeid}

    //Get all questions ; answered by subject matter expert id

    //http://localhost:5645/api/Consulting/sme/{smeid}/questions

    //Get all questions of particular subject
    //http://localhost:5645/api/Consulting/subject/{subjectid}/questions

    //put post api


    //http://localhost:5645/api/Consulting/qustions
    //http://localhost:5645/api/Consulting/qustions/{id}
    //http://localhost:5645/api/Consulting/answers
    //http://localhost:5645/api/Consulting/questionanswer/{questionid}
    //http://localhost:5645/api/Consulting/sme/questions/{smd}
    
    [HttpGet]
    [Route("questions")]
    public List<Question> GetAll()
    {

        List<Question> questions = _srv.GetAll();

        return questions;
    }


    [HttpGet]
    [Route("questions/{id}")]
    public Question GetById(int id)
    {

        Question question = _srv.GetById(id);

        return question;
    }
}
