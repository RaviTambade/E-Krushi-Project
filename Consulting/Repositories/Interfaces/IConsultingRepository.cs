using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IConsultingRepository{

    Task<List<Question>> getAllQuestions();
    Task<Question> getQuestion(int id);
    Task<List<Answer>> getAllAnswers(); 
    public Task<List<SubjectMatterExpert>> getAllExperts();
    public Task<SubjectMatterExpert> getExpert(int id);
    
    Task<List<Question>> listOfCategoryQuestions(int id);

    Task<List<QuestionAnswer>> getQuestionAnswers(int id);

     Task<List<Answer>> getAnswers(int id);
    
    Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id);

    Task<List<QuestionCategory>> getAllCategories();
    Task<QuestionCategory> getQuestionCategory(int id);

    Task<bool> AddCustomerQuestion(CustomerQuestion question);

    Task<List<CustomerQuestion>> getAllCustomerQuestion();
    Task<List<CustomerQuestion>> QuestionDetailsByCustomer(int custId);

    Task<bool> InsertQuestion(Question question); 
    
    Task<bool> DeleteQuestion(int id); 
}