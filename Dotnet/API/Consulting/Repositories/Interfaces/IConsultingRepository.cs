using Transflower.EKrushi.Consulting.Models;
namespace Transflower.EKrushi.Consulting.Repositories.Interfaces;
public interface IConsultingRepository
{

    Task<List<Question>> getAllQuestions();
    Task<Question> getQuestion(int id);
    Task<List<Answer>> getAllAnswers();
    Task<List<SubjectMatterExpert>> getAllExperts();
    Task<SubjectMatterExpert> getExpert(int id);
    Task<List<Question>> listOfCategoryQuestions(int id);
    Task<List<QuestionAnswer>> getQuestionAnswers(int id);
    Task<List<Answer>> getAnswers(int id);
    Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id);
    Task<List<QuestionCategory>> getAllCategories();
    Task<QuestionCategory> getQuestionCategory(int id);
    Task<bool> AddCustomerQuestion(CustomerQuestion question);
    Task<List<CustomerQuestion>> getAllCustomerQuestion();
    Task<List<NewQuestion>> QuestionDetailsByCustomer(int custId);
    Task<bool> InsertQuestion(Question question);
    Task<bool> DeleteQuestion(int id);
    Task<List<Question>> GetQuestions(string categoryName);
    Task<int> GetCategoryId(string categoryName);
    Task<List<QuestionAnswer>> CustomerQuestionAnswer(int questionId);
}