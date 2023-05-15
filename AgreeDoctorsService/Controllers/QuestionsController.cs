
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
    [Route("InsertQuestion")]
    public bool InsertQuestion(Question question)
    {

        bool status = _srv.InsertQuestion(question);

        return status;
    }


     [HttpPut]
    [Route("UpdateQuestion")]
    public bool UpdateQuestion(Question question)
    {

    bool status = _srv.UpdateQuestion(question);

        return status;
    }



      [HttpDelete]
    [Route("DeleteQuestion/{id}")]
    public bool DeleteQuestion(int id)
    {

        bool status = _srv.DeleteQuestion(id);

        return status;
    }
   



     

}
