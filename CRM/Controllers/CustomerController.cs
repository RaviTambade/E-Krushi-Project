using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KrushiProject.Service.Interfaces;
using KrushiProject.Models;

namespace krushiproject.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _srv;

    public CustomerController(ICustomerService srv)
    {
        _srv = srv;
    }
    
    [HttpGet]
    [Route ("getAll")]
    public IEnumerable<Customer> GetAll()
    {
        var customers = _srv.GetAllCustomers();
        return customers;
    }


   [HttpGet]
   [Route ("getcustomer/{id}")]
    public Customer GetCustomer(int id)
    {
        var customer = _srv.GetCustomer(id);
        return customer;
    }

    [HttpPost]
    [Route ("insertcustomer")]
     public bool Insert([FromBody] Customer customer)
   {    
        bool result =_srv.Insert(customer);
        return result;
   }

   
   [HttpPut]
   [Route ("updatecustomer")]
   public async Task<bool> Update(Customer customer)
   {
    bool result = await _srv.Update(customer);
    return result;

   }
   
   [HttpDelete]
   [Route ("delete/{id}")]
   public async Task<bool> Delete(int id)
   {
    bool result =await _srv.Delete(id);
    return result;
   }

 [HttpGet]
   [Route ("getuser/{id}")]
    public async Task<Customer> GetUser(int id)
    {
        var customer = await _srv.GetUser(id);
        return customer;
    }
    
   
}
