using KrushiProject.Models;
namespace KrushiProject.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();

        Customer GetCustomer(int id);

        bool Insert(Customer customer);

        Task<bool> Update(Customer customer);

        Task<bool> Delete(int id);

        Task<Customer> GetUser(int userId);
    }
}