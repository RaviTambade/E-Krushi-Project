
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

     [HttpGet]
    [Route("getbyid/{id}")]
    public Question GetById(int id)
    {

        Question question = _srv.GetById(id);

        return question;
    }


      [HttpPost]
    [Route("Insert")]
    public bool InsertDoctor(Question question)
    {

        bool status = _srv.InsertDoctor(question);

        return status;
    }


     [HttpPut]
    [Route("update")]
    public bool UpdateDoctor(Question question)
    {

    bool status = _srv.UpdateDoctor(question);

        return status;
    }



      [HttpDelete]
    [Route("Delete/{id}")]
    public bool DeleteDoctor(int id)
    {

        bool status = _srv.DeleteDoctor(id);

        return status;
    }
   



     

}
