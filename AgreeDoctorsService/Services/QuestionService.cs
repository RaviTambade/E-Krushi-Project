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
     public Question GetById(int id)=>_repo.GetById(id);
    public bool InsertQuestion(Question question)=>_repo.InsertQuestion(question);

    public bool UpdateQuestion(Question question)=>_repo.UpdateQuestion(question);

    public bool DeleteQuestion(int id)=>_repo.DeleteQuestion(id);
}