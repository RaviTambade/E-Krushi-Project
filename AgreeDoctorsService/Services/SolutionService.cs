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
    public bool Insert(Solution solution)=>_repo.Insert(solution);

    public bool Update(Solution solution)=>_repo.Update(solution);

    public bool Delete(int id)=>_repo.Delete(id);

   
}