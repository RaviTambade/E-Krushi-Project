
using Transflower.EKrushi.Consulting.Models;
namespace Transflower.EKrushi.Consulting.Repositories.Interfaces;
public interface IConsultingRepository
{

    Task<List<Question>> GetAllQuestions();
    Task<Question> GetQuestion(int id);
    Task<List<Answer>> GetAllAnswers();
    Task<List<SubjectMatterExpert>> GetAllExperts();
    Task<SubjectMatterExpert> GetExpert(int id);
    Task<List<Question>> ListOfCategoryQuestions(int id);
    Task<List<Question>> ListOfReletedQuestions(int id);
    Task<List<QuestionAnswer>> GetQuestionAnswers(int id);
    Task<List<Answer>> GetAnswers(int id);
    Task<List<SmeQuestion>> GetQuestionsRespondedBySME(int id);
    Task<List<QuestionCategory>> GetAllCategories();
    Task<QuestionCategory> GetQuestionCategory(int id);
    Task<bool> AddCustomerQuestion(CustomerQuestion question);
    Task<List<CustomerQuestion>> GetAllCustomerQuestion();
    Task<List<NewQuestion>> QuestionDetailsByCustomer(int custId);
    Task<bool> InsertQuestion(Question question);
    Task<bool> DeleteQuestion(int id);
    Task<List<Question>> GetQuestions(string categoryName);
    Task<int> GetCategoryId(string categoryName);
    Task<List<QuestionAnswer>> CustomerQuestionAnswer(int questionId);

    Task<List<NotAnsweredQuestions>> GetNotAnsweredQuestions(int userId);
}