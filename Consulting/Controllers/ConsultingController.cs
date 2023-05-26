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
    [Route("experts")]                                   //This method gives all subject matter experts available in Krishi Seva
    public async Task<List<SubjectMatterExpert>> Experts()
    {

      List<SubjectMatterExpert> experts  = await _srv.Experts();

        return experts;
    }

    [HttpGet]
    [Route("answers")]                            
    public async Task<List<Answer>> Answers()                 //This method gives Agri doctor List.
    {

        List<Answer> answers = await _srv.Answers();

        return answers;
    }

    [HttpGet]
    [Route("questions/category/{id}")]                          //This method gives agri doctor details by id.
    public async Task<List<Question>> Category(int id)
    {

        List<Question> category = await _srv.Category(id);
        return category;

    }
    [HttpGet]
    [Route("Expert/{id}")]                          //This method gives agri doctor details by id.
    
    public async Task<SubjectMatterExpert> Expert(int id)
    {

      SubjectMatterExpert expert = await  _srv.Expert(id);

        return expert;
    }
}
