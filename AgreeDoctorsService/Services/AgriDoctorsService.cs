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
    public bool InsertDoctor(AgriDoctor doctor)=>_repo.InsertDoctor(doctor);

    public bool UpdateDoctor(AgriDoctor doctor)=>_repo.UpdateDoctor(doctor);

    public bool DeleteDoctor(int id)=>_repo.DeleteDoctor(id);
}