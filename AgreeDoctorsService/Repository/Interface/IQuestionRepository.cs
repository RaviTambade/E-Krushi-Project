using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IQuestionRepository{

    public List<Question> GetAll();
}