using E_krushiApp.Models;
using E_krushiApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultingController : ControllerBase
{
    private readonly IConsultingService _srv;

    public ConsultingController(IConsultingService srv)
    {
        _srv = srv;
    }



    //This method gives question List.
    //http://localhost:5279/api/consulting/questions
    [HttpGet("questions")]

    public async Task<List<Question>> getAllQuestions()
    {

        List<Question> questions = await _srv.getAllQuestions();

        return questions;
    }



    //This method gives question details by id.
    //http://localhost:5279/api/consulting/questions/{id}
    [HttpGet("questions/{id}")]
    public async Task<Question> getQuestion(int id)
    {

        Question question = await _srv.getQuestion(id);

        return question;
    }

    //This method gives all subject matter experts available in Krishi Seva
    //http://localhost:5279/consulting/experts
    [HttpGet("experts")]
    public async Task<List<SubjectMatterExpert>> getAllExperts()
    {

        List<SubjectMatterExpert> experts = await _srv.getAllExperts();

        return experts;
    }

    //This method gives list of answers.
    //http://localhost:5279/consulting/answers

    [HttpGet("answers")]
    public async Task<List<Answer>> getAllAnswers()
    {

        List<Answer> answers = await _srv.getAllAnswers();

        return answers;
    }


    //This method gives all Question list of particular catagoryid.
    //http://localhost:5279/consulting/Questions/Catagory/{id}
    [HttpGet("Questions/Catagory/{id}")]
    public async Task<List<Question>> listOfCategoryQuestions(int id)
    {

        List<Question> category = await _srv.listOfCategoryQuestions(id);
        return category;

    }




    //This method gives agri doctor details by id.
    //http://localhost:5279/consulting/Expert/{id}
    [HttpGet("Expert/{id}")]
    public async Task<SubjectMatterExpert> getExpert(int id)
    {

        SubjectMatterExpert expert = await _srv.getExpert(id);

        return expert;
    }



    //this method gives question answers particular agri doctor  id. 
    //http://localhost:5279/consulting/questionsanswers/sme/{id}
    [HttpGet("questionsanswers/sme/{id}")]
    public async Task<List<QuestionAnswer>> getQuestionAnswers(int id)
    {

        List<QuestionAnswer> questionAnswers = await _srv.getQuestionAnswers(id);
        return questionAnswers;

    }


    //This method gives answers  of particular provided question id.
    //http://localhost:5279/consulting/answers/{id}
    [HttpGet("answers/{id}")]
    public async Task<List<Answer>> getAnswers(int id)
    {

        List<Answer> answers = await _srv.getAnswers(id);
        return answers;

    }


    //questions solved by particular sme

    //http://localhost:5279/consulting/smequestions/{id}
    [HttpGet("smequestions/{id}")]
    public async Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id)
    {

        List<SmeQuestion> questions = await _srv.getQuestionsRespondedBySME(id);
        return questions;

    }



    // this method gives all questioncategories.
    //http://localhost:5279/consulting/questioncatagories
    [HttpGet("questioncatagories")]
    public async Task<List<QuestionCategory>> getAllCategories()
    {

        List<QuestionCategory> categories = await _srv.getAllCategories();
        return categories;

    }


    //  this method gives catagory of question.
    //http://localhost:5279/consulting/catagory/question/{id}
    [HttpGet("catagory/question/{id}")]
    public async Task<QuestionCategory> getQuestionCategory(int id)
    {

        QuestionCategory category = await _srv.getQuestionCategory(id);
        return category;

    }


}
