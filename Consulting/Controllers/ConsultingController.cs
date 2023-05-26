using E_krushiApp.Models;
using E_krushiApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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


    [HttpGet]
    [Route("questions")]                            
    public async Task<List<Question>> Questions()                 //This method gives Agri doctor List.
    {

        List<Question> questions = await _srv.Questions();

        return questions;
    }


    [HttpGet]
    [Route("questions/{id}")]                          //This method gives agri doctor details by id.
    public async Task<Question> Question(int id)
    {

        Question question = await _srv.Question(id);

        return question;
    }



    [HttpGet]
    [Route("experts")]                          
    public async Task<List<SubjectMatterExpert>> Experts()
    {

      List<SubjectMatterExpert> experts  = await _srv.Experts();

        return experts;
    }
}