using KrushiProject.Service.Interfaces;
using KrushiProject.Models;
using KrushiProject.Repositories.Interfaces;

namespace KrushiProject.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
            public CustomerService(ICustomerRepository repo)
            {
                _repo = repo;
            }

            public async Task<List<Customer>> GetAllCustomers() => await _repo.GetAllCustomers();
            public async Task<Customer> GetCustomer(int id)=> await _repo.GetCustomer(id);
            public async Task<bool> Insert(Customer customer)=> await _repo.Insert(customer);
            public Task<bool> Update(Customer customer)=>_repo.Update(customer);
            public Task<bool> Delete(int id)=>_repo.Delete(id);
            public async Task<Customer> GetUser(int id) =>  await _repo.GetUser(id);

       
    }
}
