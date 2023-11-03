using Transflower.EKrushi.Consulting.Models;
using Transflower.EKrushi.Consulting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Transflower.EKrushi.Consulting.Helpers;
namespace Transflower.EKrushi.Consulting.Controllers;

[ApiController]
[Route("api/consulting")]
public class ConsultingController : ControllerBase
{
    private readonly IConsultingService _service;
    public ConsultingController(IConsultingService consultingService)
    {
        _service = consultingService;
    }

    //This method gives question List.
    //http://localhost:5279/api/consulting
    public async Task<List<Question>> GetAllQuestions()
    {
        List<Question> questions = await _service.GetAllQuestions();
        return questions;
    }

    //This method gives question details by id.
    //http://localhost:5279/api/consulting/questions/{id}
    [HttpGet("questions/{id}")]
    public async Task<Question> GetQuestion(int id)
    {
        Question question = await _service.GetQuestion(id);
        return question;
    }

    //This method gives all subject matter experts available in Krishi Seva
    //http://localhost:5279/consulting/experts
    [Authorize]
    [HttpGet("experts")]
    public async Task<List<SubjectMatterExpert>> GetAllExperts()
    {
        List<SubjectMatterExpert> experts = await _service.GetAllExperts();
        return experts;
    }

    //This method gives list of answers.
    //http://localhost:5279/consulting/answers
    [HttpGet("answers")]
    public async Task<List<Answer>> GetAllAnswers()
    {
        List<Answer> answers = await _service.GetAllAnswers();
        return answers;
    }

    //This method gives all Question list of particular catagoryid.
    //http://localhost:5279/consulting/Questions/Catagory/{id}
    [HttpGet("Questions/Catagory/{id}")]
    public async Task<List<Question>> ListOfCategoryQuestions(int id)
    {
        List<Question> category = await _service.ListOfCategoryQuestions(id);
        return category;
    }


     //releted questions
    //http://localhost:5279/consulting/reletedquestions/{id}
    [HttpGet("reletedquestions/{id}")]
    public async Task<List<Question>> ListOfReletedQuestions(int id)
    {
        List<Question> questions = await _service.ListOfReletedQuestions(id);
        return questions;
    }

    //This method gives agri doctor details by id.
    //http://localhost:5279/consulting/Expert/{id}
    [HttpGet("Expert/{id}")]
    public async Task<SubjectMatterExpert> GetExpert(int id)
    {
        SubjectMatterExpert expert = await _service.GetExpert(id);
        return expert;
    }

    //this method gives question answers particular agri doctor  id. 
    //http://localhost:5279/consulting/questionsanswers/sme/{id}
    [HttpGet("questionsanswers/sme/{id}")]
    public async Task<List<QuestionAnswer>> GetQuestionAnswers(int id)
    {
        List<QuestionAnswer> questionAnswers = await _service.GetQuestionAnswers(id);
        return questionAnswers;
    }

    //This method gives answers  of particular provided question id.
    //http://localhost:5279/api/consulting/answers/{id}
    [HttpGet("answers/{id}")]
    public async Task<List<Answer>> GetAnswers(int id)
    {
        List<Answer> answers = await _service.GetAnswers(id);
        return answers;
    }

    //questions solved by particular sme
    //http://localhost:5279/consulting/smequestions/{id}
    [HttpGet("smequestions/{id}")]
    public async Task<List<SmeQuestion>> GetQuestionsRespondedBySME(int id)
    {
        List<SmeQuestion> questions = await _service.GetQuestionsRespondedBySME(id);
        return questions;
    }

    // this method gives all questioncategories.
    //http://localhost:5279/consulting/questioncatagories
    [HttpGet("questioncatagories")]
    public async Task<List<QuestionCategory>> GetAllCategories()
    {
        List<QuestionCategory> categories = await _service.GetAllCategories();
        return categories;

    }

    //  this method gives catagory of question.
    //http://localhost:5279/consulting/catagory/question/{id}
    [HttpGet("catagory/question/{id}")]
    public async Task<QuestionCategory> GetQuestionCategory(int id)
    {
        QuestionCategory category = await _service.GetQuestionCategory(id);
        return category;
    }

    //this method used to add customerquestion.
    //http://localhost:5279/consulting/customerquestion

    [HttpPost("customerquestion")]
    public async Task<bool> AddCustomerQuestion(CustomerQuestion question)
    {
        bool status = await _service.AddCustomerQuestion(question);
        return status;
    }

    //this method is used to get all customerquestions.
    //http://localhost:5279/consulting/getallcustomerquestions

    [HttpGet("getallcustomerquestions")]
    public async Task<List<CustomerQuestion>> GetAllCustomerQuestion()
    {
        List<CustomerQuestion> questions = await _service.GetAllCustomerQuestion();
        return questions;
    }

    //this method gives duestions details by customer id.
    //http://localhost:5279/consulting/questionDetails/{custId}
    [HttpGet("questionDetails/{custId}")]
    public async Task<List<NewQuestion>> QuestionDetailsByCustomer(int custId)
    {
        List<NewQuestion> questions = await _service.QuestionDetailsByCustomer(custId);
        return questions;
    }

    //this method is used for insert question.
    //http://localhost:5279/consulting/question
    [HttpPost("question")]
    public async Task<bool> InsertQuestion(Question question)
    {
        bool status = await _service.InsertQuestion(question);
        return status;
    }

    //this method is used for delete question by particular id.
    //http://localhost:5279/consulting/deleteQuestion/{id}

    [HttpDelete("deleteQuestion/{id}")]
    public async Task<bool> DeleteQuestion(int id)
    {
        bool status = await _service.DeleteQuestion(id);
        return status;
    }

    //this method gives categorywise question list.
    //http://localhost:5279/consulting/categoryquestions/{categoryName}
    [HttpGet("categoryquestions/{categoryName}")]
    public async Task<List<Question>> GetQuestions(string categoryName)
    {
        List<Question> questions = await _service.GetQuestions(categoryName);
        return questions;
    }

    //this method gives category id of provided question.
    //http://localhost:5279/consulting/categoryid/{categoryName}

    [HttpGet("categoryid/{categoryName}")]
    public async Task<int> GetCategoryId(string categoryName)
    {
        int categoryId = await _service.GetCategoryId(categoryName);
        return categoryId;
    }

    //this method gives us answer of provided question id.
    //http://localhost:5279/consulting/customerquestionanswer/{questionId}

    [HttpGet("customerquestionanswer/{questionId}")]
    public async Task<List<QuestionAnswer>> CustomerQuestionAnswer(int questionId)
    {
        List<QuestionAnswer> answers = await _service.CustomerQuestionAnswer(questionId);
        return answers;
    }



     [HttpGet("NotAnsweredQuestions/{userId}")]
        public async Task<List<NotAnsweredQuestions>> GetNotAnsweredQuestions(int userId)
        {
            List<NotAnsweredQuestions> questions=await _service.GetNotAnsweredQuestions(userId);
            return questions; 
        }
}
