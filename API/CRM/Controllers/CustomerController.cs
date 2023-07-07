using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KrushiProject.Service.Interfaces;
using KrushiProject.Models;

namespace krushiproject.Controllers;

[ApiController]
[Route("/api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _srv;

    public CustomerController(ICustomerService srv)
    {
        _srv = srv;
    }
    
    [HttpGet]
    public async Task<List<Customer>> GetAll()
    {
        List<Customer> customers = await _srv.GetAll();
        return customers;
    }


   [HttpGet]
   [Route ("{id}")]
    public async Task<Customer> GetById(int id)
    {
        Customer customer = await _srv.GetById(id);
        return customer;
    }

    [HttpPost]
    public async Task<bool> Insert([FromBody] Customer customer)
    {    
        bool result = await _srv.Insert(customer);
        return result;
    }

   
   [HttpPut]
   public async Task<bool> Update(Customer customer)
   {
    bool result = await _srv.Update(customer);
    return result;

   }
   
   [HttpDelete]
   [Route ("{id}")]
   public async Task<bool> Delete(int id)
   {
    bool result =await _srv.Delete(id);
    return result; 
   }

   [HttpGet]
   [Route ("user/{id}")]
    public async Task<Customer> GetByUserId(int id)
    {
        var customer = await _srv.GetByUserId(id);
        return customer;
    }
   
}
