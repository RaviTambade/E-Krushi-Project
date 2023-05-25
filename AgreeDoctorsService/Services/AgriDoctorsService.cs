using E_krushiApp.Models;
using E_krushiApp.Repository.Interface.IAgriDoctor;
using E_krushiApp.Services.Interface.IAgriDoctorsService;
namespace E_krushiApp.Services.AgriDoctors;
public class AgriDoctorsService : IAgriDoctorsService
{
    private readonly IAgriRepository _repo;


   public AgriDoctorsService(IAgriRepository repo){

        _repo=repo;
    }

    
    public List<AgriDoctor> GetAll()=> _repo.GetAll();

    public AgriDoctor GetById(int id)=>_repo.GetById(id);
    public bool Insert(AgriDoctor doctor)=>_repo.Insert(doctor);

    public bool Update(AgriDoctor doctor)=>_repo.Update(doctor);

    public bool Delete(int id)=>_repo.Delete(id);
}