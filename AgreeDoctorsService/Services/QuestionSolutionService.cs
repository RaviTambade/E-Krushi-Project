using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using E_krushiApp.Models;
namespace E_krushiApp.Services;
public class QuestionSolutionService:IQuestionSolutionService{

    private readonly IQuestionSolutionRepository _repo;

    public QuestionSolutionService(IQuestionSolutionRepository repo){

        _repo=repo;
    }

    public List<QuestionSolution> GetAll() => _repo.GetAll();

    public QuestionSolution GetById(int id)=>_repo.GetById(id);

    public bool InsertQuestionSolution(QuestionSolution questionSolution)=>_repo.InsertQuestionSolution(questionSolution);

    public bool UpdateQuestionSolution(QuestionSolution questionSolution)=>_repo.UpdateQuestionSolution(questionSolution);

    public bool DeleteQuestionSolution(int id)=>_repo.DeleteQuestionSolution(id);

}