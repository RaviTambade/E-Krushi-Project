
using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface ISolutionRepository{


    public List<Solution> GetAll(); 

    public Solution GetById(int id);

    public bool Insert(Solution solution);
     
    public bool Update(Solution solution);
    
    public bool Delete(int id);
}