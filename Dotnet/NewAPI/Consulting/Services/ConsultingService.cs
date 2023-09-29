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

    public async Task<List<Question>> getAllQuestions() => await _repository.getAllQuestions();
    public async Task<Question> getQuestion(int id) => await _repository.getQuestion(id);
    public async Task<List<Answer>> getAllAnswers() => await _repository.getAllAnswers();
    public async Task<List<SubjectMatterExpert>> getAllExperts() => await _repository.getAllExperts();
    public async Task<List<Question>> listOfCategoryQuestions(int id) => await _repository.listOfCategoryQuestions(id);
    public async Task<List<Question>> listOfReletedQuestions(int id) => await _repository.listOfReletedQuestions(id);
    public async Task<SubjectMatterExpert> getExpert(int id) => await _repository.getExpert(id);
    public async Task<List<QuestionAnswer>> getQuestionAnswers(int id) => await _repository.getQuestionAnswers(id);
    public async Task<List<Answer>> getAnswers(int id) => await _repository.getAnswers(id);
    public async Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id) => await _repository.getQuestionsRespondedBySME(id);
    public async Task<List<QuestionCategory>> getAllCategories() => await _repository.getAllCategories();
    public async Task<QuestionCategory> getQuestionCategory(int id) => await _repository.getQuestionCategory(id);
    public async Task<bool> AddCustomerQuestion(CustomerQuestion question) => await _repository.AddCustomerQuestion(question);
    public async Task<List<CustomerQuestion>> getAllCustomerQuestion() => await _repository.getAllCustomerQuestion();
    public async Task<List<NewQuestion>> QuestionDetailsByCustomer(int custId) => await _repository.QuestionDetailsByCustomer(custId);
    public async Task<bool> InsertQuestion(Question question) => await _repository.InsertQuestion(question);
    public async Task<bool> DeleteQuestion(int id) => await _repository.DeleteQuestion(id);
    public async Task<List<Question>> GetQuestions(string categoryName) => await _repository.GetQuestions(categoryName);
    public async Task<int> GetCategoryId(string categoryName) => await _repository.GetCategoryId(categoryName);
    public async Task<List<QuestionAnswer>> CustomerQuestionAnswer(int questionId) => await _repository.CustomerQuestionAnswer(questionId);
}