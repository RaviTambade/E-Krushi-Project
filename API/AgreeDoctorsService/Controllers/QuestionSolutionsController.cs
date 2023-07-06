
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
    [Route("Solutions")]
    public List<QuestionSolution> GetAll()
    {

        List<QuestionSolution> solutions = _srv.GetAll();

        return solutions;
    }

     [HttpGet]
    [Route("Solutions/{id}")]
    public QuestionSolution GetById(int id)
    {

        QuestionSolution solutions = _srv.GetById(id);

        return solutions;
    }


    [HttpPost]
    [Route("Insert")]
    public bool Insert(QuestionSolution solution)
    {

        bool status = _srv.Insert(solution);

        return status;
    }


     [HttpPut]
    [Route("Update")]
    public bool Update(QuestionSolution solution)
    {

    bool status = _srv.Update(solution);

        return status;
    }



      [HttpDelete]
    [Route("Delete/{id}")]
    public bool Delete(int id)
    {

        bool status = _srv.Delete(id);

        return status;
    }
   
}
