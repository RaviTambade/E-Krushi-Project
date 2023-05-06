
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


    [HttpPost]
    [Route("InsertQuestionSolution")]
    public bool InsertQuestionSolution(QuestionSolution questionSolution)
    {

        bool status = _srv.InsertQuestionSolution(questionSolution);

        return status;
    }


     [HttpPut]
    [Route("UpdateQuestionSolution")]
    public bool UpdateQuestionSolution(QuestionSolution questionSolution)
    {

    bool status = _srv.UpdateQuestionSolution(questionSolution);

        return status;
    }



      [HttpDelete]
    [Route("DeleteDeleteQuestionSolution/{id}")]
    public bool DeleteQuestionSolution(int id)
    {

        bool status = _srv.DeleteQuestionSolution(id);

        return status;
    }
   
}
