using E_krushiApp.Models;

namespace E_krushiApp.Repository.Interface.IAgriDoctor;

public interface IAgri{

    public List<AgriDoctor> GetAll();

    public AgriDoctor GetById(int id);
}