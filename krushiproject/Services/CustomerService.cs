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
            public bool Update(Customer customer)=>_repo.Update(customer);
            public bool Delete(int id)=>_repo.Delete(id);
            public Customer GetUser(int id) => _repo.GetUser(id);

       
    }
}
