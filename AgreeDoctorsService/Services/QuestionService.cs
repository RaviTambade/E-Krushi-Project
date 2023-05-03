using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using E_krushiApp.Models;
namespace E_krushiApp.Services;
public class QuestionService:IQuestionService{

    private readonly IQuestionRepository _repo;

    public QuestionService(IQuestionRepository repo){

        _repo=repo;
    }

    public List<Question> GetAll() => _repo.GetAll();
}