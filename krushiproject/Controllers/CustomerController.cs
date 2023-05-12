using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using krushiproject.Models;
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

    // public IActionResult GetAllCustomers()
    // {

    //     return View();
    // }
    
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
        bool result =_srv.InsertCustomer(customer);
        return result;
   }
  
   [HttpPut]
   [Route ("updatecustomer/{id}")]
   public bool Update(int id,[FromBody] Customer customer)
   {
        Customer oldcustomer = _srv.GetCustomer(id);
        if(oldcustomer.CustId==0){
            return false;
        }
        customer.CustId= id;
        bool result =_srv.UpdateCustomer(customer);
        return result;
   }
   
   [HttpDelete]
   [Route ("delete/{id}")]
   public bool Delete(int id)
   {
    bool result = _srv.DeleteCustomer(id);
    return result;
   }


    
   
}
