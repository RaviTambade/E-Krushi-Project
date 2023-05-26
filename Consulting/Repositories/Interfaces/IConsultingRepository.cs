using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IConsultingRepository{

    Task<List<Question>> Questions();

    Task<Question> Question(int id);

}