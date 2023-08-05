using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using E_krushiApp.Models;
namespace E_krushiApp.Services;
public class ConsultingService:IConsultingService{

    private readonly IConsultingRepository _repo;

    public ConsultingService(IConsultingRepository repo){

        _repo=repo;
    }

    public async Task<List<Question>> getAllQuestions() => await _repo.getAllQuestions();
    public async Task<Question> getQuestion(int id) => await _repo.getQuestion(id);
    public async Task<List<Answer>> getAllAnswers() => await _repo.getAllAnswers(); 
    public async Task<List<SubjectMatterExpert>> getAllExperts()=> await _repo.getAllExperts();
    public async Task<List<Question>> listOfCategoryQuestions(int id) => await _repo.listOfCategoryQuestions(id);
    public async Task<SubjectMatterExpert> getExpert(int id) => await _repo.getExpert(id);
    public async Task<List<QuestionAnswer>> getQuestionAnswers(int id) => await _repo.getQuestionAnswers(id);
    public async Task<List<Answer>> getAnswers(int id) => await _repo.getAnswers(id);

   public async Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id) => await _repo.getQuestionsRespondedBySME(id);

    public async Task<List<QuestionCategory>> getAllCategories()=> await _repo.getAllCategories();
    public async Task<QuestionCategory> getQuestionCategory(int id)=> await _repo.getQuestionCategory(id);

    public async Task<bool> AddCustomerQuestion(CustomerQuestion question)=> await _repo.AddCustomerQuestion(question);


    public async Task<List<CustomerQuestion>> getAllCustomerQuestion() => await _repo.getAllCustomerQuestion(); 
    
     public async Task<List<NewQuestion>> QuestionDetailsByCustomer(int custId) => await _repo.QuestionDetailsByCustomer(custId); 

    public async Task<bool> InsertQuestion(Question question)=> await _repo.InsertQuestion(question);

     public async Task<bool> DeleteQuestion(int id)=> await _repo.DeleteQuestion(id);
    public async Task<List<Question>> GetQuestions(string categoryName) => await _repo.GetQuestions(categoryName); 
    
    public async Task<int> GetCategoryId(string categoryName) => await _repo.GetCategoryId(categoryName); 

    public async Task<List<QuestionAnswer>> CustomerQuestionAnswer(int questionId) => await _repo.CustomerQuestionAnswer(questionId);

    
}