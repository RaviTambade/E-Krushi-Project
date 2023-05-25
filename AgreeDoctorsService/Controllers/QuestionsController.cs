
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
    [Route("GetAllQuestions")]
    public List<Question> GetAll()
    {

        List<Question> questions = _srv.GetAll();

        return questions;
    }

     [HttpGet]
    [Route("getbyid/{id}")]
    public Question GetById(int id)
    {

        Question question = _srv.GetById(id);

        return question;
    }


      [HttpPost]
    [Route("Insert")]
    public bool InsertQuestion(Question question)
    {

        bool status = _srv.Insert(question);

        return status;
    }


     [HttpPut]
    [Route("Update")]
    public bool Update(Question question)
    {

    bool status = _srv.Update(question);

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
