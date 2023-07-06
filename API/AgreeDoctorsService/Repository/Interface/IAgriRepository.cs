using E_krushiApp.Models;

namespace E_krushiApp.Repository.Interface.IAgriDoctor;

public interface IAgriRepository{

    public List<AgriDoctor> GetAll();

    public AgriDoctor GetById(int id);

    public bool Insert(AgriDoctor doctor);


    public bool Update(AgriDoctor doctor);
    public bool Delete(int id);

}