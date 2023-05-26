using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using E_krushiApp.Models;
namespace E_krushiApp.Services;
public class ConsultingService:IConsultingService{

    private readonly IConsultingRepository _repo;

    public ConsultingService(IConsultingRepository repo){

        _repo=repo;
    }

    public async Task<List<Question>> Questions() => await _repo.Questions();
    public async Task<Question> Question(int id) => await _repo.Question(id);
    public async Task<List<Answer>> Answers() => await _repo.Answers(); 
    public async Task<List<SubjectMatterExpert>> Experts()=> await _repo.Experts();
    public async Task<List<Question>> Category(int id) => await _repo.Category(id);
    public async Task<SubjectMatterExpert> Expert(int id) => await _repo.Expert(id);

}