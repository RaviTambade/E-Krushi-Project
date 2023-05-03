using E_krushiApp.Models;
using E_krushiApp.Repository.Interface.IAgriDoctor;
using E_krushiApp.Services.Interface.IAgriDoctorsService;
namespace E_krushiApp.Services.AgriDoctors;
public class AgriDoctorsService : IAgriDoctorsService
{
    private readonly IAgri _repo;


   public AgriDoctorsService(IAgri repo){

        _repo=repo;
    }

    
    public List<AgriDoctor> GetAll()=> _repo.GetAll();

    public AgriDoctor GetById(int id)=>_repo.GetById(id);
}