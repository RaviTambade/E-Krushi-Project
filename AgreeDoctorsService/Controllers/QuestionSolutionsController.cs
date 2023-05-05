
using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionSolutionsController : ControllerBase
{


    private readonly IQuestionSolutionService _srv;

    public QuestionSolutionsController(IQuestionSolutionService srv)
    {
        _srv = srv;
    }


    [HttpGet]
    [Route("getall")]
    public List<QuestionSolution> GetAll()
    {

        List<QuestionSolution> questionSolutions = _srv.GetAll();

        return questionSolutions;
    }

     [HttpGet]
    [Route("getbyid/{id}")]
    public QuestionSolution GetById(int id)
    {

        QuestionSolution questionSolution = _srv.GetById(id);

        return questionSolution;
    }




     

}
