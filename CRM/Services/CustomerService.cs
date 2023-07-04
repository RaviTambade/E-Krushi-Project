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

            public List<Customer> GetAllCustomers() => _repo.GetAllCustomers();
            public Customer GetCustomer(int id)=>_repo.GetCustomer(id);
            public bool Insert(Customer customer)=>_repo.Insert(customer);
            public async Task<bool> Update(Customer customer)=>await _repo.Update(customer);
            public async Task<bool> Delete(int id)=> await _repo.Delete(id);
            public async  Task<Customer> GetUser(int id) =>await  _repo.GetUser(id);

       
    }
}
