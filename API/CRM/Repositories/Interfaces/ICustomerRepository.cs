using KrushiProject.Models;
namespace KrushiProject.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomer(int id);

        Task<bool> Insert(Customer customer);

        Task<bool> Update(Customer customer);

        Task<bool> Delete(int id);

        Task<Customer> GetUser(int userId);
    }
}