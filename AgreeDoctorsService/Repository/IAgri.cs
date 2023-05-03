using E_krushiApp.Models;

namespace E_krushiApp.Repository.Interface.IAgriDoctor;

public interface IAgri{

    public List<AgriDoctor> GetAll();

    public AgriDoctor GetById(int id);

    public bool InsertDoctor(AgriDoctor doctor);


    public bool UpdateDoctor(AgriDoctor doctor);
    public bool DeleteDoctor(int id);

}