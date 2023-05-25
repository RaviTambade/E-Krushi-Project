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

    public bool Insert(QuestionSolution solution)=>_repo.Insert(solution);

    public bool Update(QuestionSolution solution)=>_repo.Update(solution);

    public bool Delete(int id)=>_repo.Delete(id);

}