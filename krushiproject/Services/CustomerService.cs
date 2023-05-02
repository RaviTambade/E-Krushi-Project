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
            public bool InsertCustomer(Customer customer)=>_repo.InsertCustomer(customer);
            public bool UpdateCustomer(Customer customer)=>_repo.UpdateCustomer(customer);
            public bool DeleteCustomer(int id)=>_repo.DeleteCustomer(id);
            public Customer GetUser(int id) => _repo.GetUser(id);

       
    }
}
