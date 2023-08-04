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

            public async Task<List<Customer>> GetAll() => await _repo.GetAll();
            public async Task<Customer> GetById(int id)=> await _repo.GetById(id);
            public async Task<bool> Insert(Customer customer)=> await _repo.Insert(customer);
            public Task<bool> Update(Customer customer)=>_repo.Update(customer);
            public Task<bool> Delete(int id)=>_repo.Delete(id);
            public async Task<Customer> GetByUserId(int id) =>  await _repo.GetByUserId(id);
            public async Task<List<CustomerReport>> GetCustomerReport(int custId) => await _repo.GetCustomerReport(custId);
       
    }
}
