using Transflower.EKrushi.CRM.Models;
namespace Transflower.EKrushi.CRM.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();

        Task<Customer> GetById(int id);

        Task<bool> Insert(Customer customer);

        Task<bool> Update(Customer customer);

        Task<bool> Delete(int id);

        Task<Customer> GetByUserId(int userId);


    }
}