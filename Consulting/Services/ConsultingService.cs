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
    public async Task<List<Question>> getCategory(int id) => await _repo.getCategory(id);
    public async Task<SubjectMatterExpert> getExpert(int id) => await _repo.getExpert(id);
    public async Task<List<QuestionAnswer>> getQuestionAnswers(int id) => await _repo.getQuestionAnswers(id);
    public async Task<List<Solution>> getAnswers(int id) => await _repo.getAnswers(id);

   public async Task<List<SmeQuestion>> getQuestionsRespondedBySME(int id) => await _repo.getQuestionsRespondedBySME(id);
}