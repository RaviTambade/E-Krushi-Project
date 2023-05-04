
using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface ISolutionRepository{


    public List<Solution> GetAll(); 

    public Solution GetById(int id);

    public bool InsertSolution(Solution solution);
     
    public bool UpdateSolution(Solution solution);
    
    public bool DeleteSolution(int id);
}