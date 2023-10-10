using Transflower.EKrushi.Consulting.Repositories.Interfaces;
using Transflower.EKrushi.Consulting.Services.Interfaces;
using Transflower.EKrushi.Consulting.Models;
namespace Transflower.EKrushi.Consulting.Services;
public class ConsultingService : IConsultingService
{
    private readonly IConsultingRepository _repository;

    public ConsultingService(IConsultingRepository repo)
    {
        _repository = repo;
    }

    public async Task<List<Question>> GetAllQuestions() => await _repository.GetAllQuestions();
    public async Task<Question> GetQuestion(int id) => await _repository.GetQuestion(id);
    public async Task<List<Answer>> GetAllAnswers() => await _repository.GetAllAnswers();
    public async Task<List<SubjectMatterExpert>> GetAllExperts() => await _repository.GetAllExperts();
    public async Task<List<Question>> ListOfCategoryQuestions(int id) => await _repository.ListOfCategoryQuestions(id);
    public async Task<List<Question>> ListOfReletedQuestions(int id) => await _repository.ListOfReletedQuestions(id);
    public async Task<SubjectMatterExpert> GetExpert(int id) => await _repository.GetExpert(id);
    public async Task<List<QuestionAnswer>> GetQuestionAnswers(int id) => await _repository.GetQuestionAnswers(id);
    public async Task<List<Answer>> GetAnswers(int id) => await _repository.GetAnswers(id);
    public async Task<List<SmeQuestion>> GetQuestionsRespondedBySME(int id) => await _repository.GetQuestionsRespondedBySME(id);
    public async Task<List<QuestionCategory>> GetAllCategories() => await _repository.GetAllCategories();
    public async Task<QuestionCategory> GetQuestionCategory(int id) => await _repository.GetQuestionCategory(id);
    public async Task<bool> AddCustomerQuestion(CustomerQuestion question) => await _repository.AddCustomerQuestion(question);
    public async Task<List<CustomerQuestion>> GetAllCustomerQuestion() => await _repository.GetAllCustomerQuestion();
    public async Task<List<NewQuestion>> QuestionDetailsByCustomer(int custId) => await _repository.QuestionDetailsByCustomer(custId);
    public async Task<bool> InsertQuestion(Question question) => await _repository.InsertQuestion(question);
    public async Task<bool> DeleteQuestion(int id) => await _repository.DeleteQuestion(id);
    public async Task<List<Question>> GetQuestions(string categoryName) => await _repository.GetQuestions(categoryName);
    public async Task<int> GetCategoryId(string categoryName) => await _repository.GetCategoryId(categoryName);
    public async Task<List<QuestionAnswer>> CustomerQuestionAnswer(int questionId) => await _repository.CustomerQuestionAnswer(questionId);
}