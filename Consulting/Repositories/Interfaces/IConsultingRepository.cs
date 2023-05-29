using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IConsultingRepository{

    Task<List<Question>> getAllQuestions();
    Task<Question> getQuestion(int id);
    Task<List<Answer>> getAllAnswers(); 
    public Task<List<SubjectMatterExpert>> getAllExperts();
    public Task<SubjectMatterExpert> getExpert(int id);
    
    Task<List<Question>> getCategory(int id);

    Task<List<QuestionAnswer>> getQuestionAnswers(int id);

     Task<List<Solution>> getAnswers(int id);
    
    Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id);
}