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



    //This method gives question List.
    [HttpGet("questions")]

    public async Task<List<Question>> Questions()
    {

        List<Question> questions = await _srv.Questions();

        return questions;
    }



    //This method gives question details by id.
    [HttpGet("questions/{id}")]
    public async Task<Question> Question(int id)
    {

        Question question = await _srv.Question(id);

        return question;
    }








    //This method gives all subject matter experts available in Krishi Seva
    [HttpGet("experts")]
    public async Task<List<SubjectMatterExpert>> Experts()
    {

        List<SubjectMatterExpert> experts = await _srv.Experts();

        return experts;
    }




    //This method gives list of answers.

    [HttpGet("answers")]
    public async Task<List<Answer>> Answers()
    {

        List<Answer> answers = await _srv.Answers();

        return answers;
    }


    //This method gives all Question list of particular catagoryid.
    [HttpGet("Questions/Catagory/{id}")]
    public async Task<List<Question>> Category(int id)
    {

        List<Question> category = await _srv.Category(id);
        return category;

    }




    //This method gives agri doctor details by id.
    [HttpGet("Expert/{id}")]
    public async Task<SubjectMatterExpert> Expert(int id)
    {

        SubjectMatterExpert expert = await _srv.Expert(id);

        return expert;
    }



    //this method gives question answers particular agri doctor  id. 
    [HttpGet("questionsanswers/sme/{id}")]
    public async Task<List<QuestionAnswer>> GetQuestionAnswers(int id)
    {

        List<QuestionAnswer> questionAnswers = await _srv.GetQuestionAnswers(id);
        return questionAnswers;

    }


    //This method gives answers  of particular provided question id.
    [HttpGet("answers/{id}")]
    public async Task<List<Solution>> Answers(int id)
    {

        List<Solution> answers = await _srv.Answers(id);
        return answers;

    }


    //questions solved by particular sme


     [HttpGet("smequestions/{id}")]
    public async Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id)
    {

        List<SmeQuestion> questions = await _srv.getQuestionsRespondedBySME(id);
        return questions;

    }
}
