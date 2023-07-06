using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IConsultingRepository{

    public List<Question> Questions();

    public Question GetQuestion(int id);

}