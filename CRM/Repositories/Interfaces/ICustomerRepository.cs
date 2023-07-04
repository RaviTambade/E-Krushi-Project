using KrushiProject.Models;
namespace KrushiProject.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomer(int id);

        Task<bool> Insert(Customer customer);

        bool Update(Customer customer);

        bool Delete(int id);

        Customer GetUser(int userId);
    }
}