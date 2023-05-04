using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using E_krushiApp.Models;
namespace E_krushiApp.Services;
public class SolutionService:ISolutionService{

    private readonly ISolutionRepository _repo;

    public SolutionService(ISolutionRepository repo){

        _repo=repo;
    }

    public List<Solution> GetAll() => _repo.GetAll();
     public Solution GetById(int id)=>_repo.GetById(id);
    public bool InsertSolution(Solution solution)=>_repo.InsertSolution(solution);

    public bool UpdateSolution(Solution solution)=>_repo.UpdateSolution(solution);

    public bool DeleteSolution(int id)=>_repo.DeleteSolution(id);

   
}