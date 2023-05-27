using KrushiProject.Models;
namespace KrushiProject.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();

        Customer GetCustomer(int id);

        bool Insert(Customer customer);

        bool Update(Customer customer);

        bool Delete(int id);

        Customer GetUser(int userId);
    }
}