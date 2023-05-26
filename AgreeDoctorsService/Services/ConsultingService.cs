using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using E_krushiApp.Models;
namespace E_krushiApp.Services;
public class ConsultingService:IConsultingService{

    private readonly IConsultingRepository _repo;

    public ConsultingService(IConsultingRepository repo){

        _repo=repo;
    }

    public async Task<List<Question>> Questions()
    {
       await _repo.Questions();
    } 

    public async Task<Question> GetById(int id)
    {
        await _repo.GetQuestion(id);
    }
}