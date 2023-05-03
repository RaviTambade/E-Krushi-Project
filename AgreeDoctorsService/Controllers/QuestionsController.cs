
using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{


    private readonly IQuestionService _srv;

    public QuestionsController(IQuestionService srv)
    {
        _srv = srv;
    }


    [HttpGet]
    [Route("getall")]
    public List<Question> GetAll()
    {

        List<Question> questions = _srv.GetAll();

        return questions;
    }


   



     

}
