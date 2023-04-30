using KrushiProject.Service.Interfaces;
using KrushiProject.Models;

namespace KrushiProject.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerService _srv;
            public CustomerService(ICustomerService srv)
            {
                _srv = srv;
            }

            public List<Customer> GetAllCustomers() => _srv.GetAllCustomers();
            public Customer GetCustomer(int id)=>_srv.GetCustomer(id);
            public bool InsertCustomer(Customer customer)=>_srv.InsertCustomer(customer);
            public bool UpdateCustomer(Customer customer)=>_srv.UpdateCustomer(customer);
            public bool DeleteCustomer(int id)=>_srv.DeleteCustomer(id);
            public Customer GetUser(int id) => _srv.GetUser(id);

       
    }
}
