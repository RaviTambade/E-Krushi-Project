using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Transflower.EKrushi.CRM.Interfaces;
using Transflower.EKrushi.CRM.Models;
using Transflower.EKrushi.CRM.Helpers;

namespace krushiproject.Controllers;

[ApiController]
[Route("/api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    //http://localhost:5027/api/customers
    [Authorize]
    [HttpGet]
    public async Task<List<Customer>> GetAll()
    {
        List<Customer> customers = await _service.GetAll();
        return customers;
    }

    //http://localhost:5027/api/customers/customer/{id}
    [HttpGet]
    [Route("customer/{id}")]
    public async Task<Customer> GetById(int id)
    {
        Customer customer = await _service.GetById(id);
        return customer;
    }

    //http://localhost:5027/api/customers
    [HttpPost]
    public async Task<bool> Insert([FromBody] Customer customer)
    {
        bool result = await _service.Insert(customer);
        return result;
    }

    //http://localhost:5027/api/customers
    [HttpPut]
    public async Task<bool> Update(Customer customer)
    {
        bool result = await _service.Update(customer);
        return result;
    }

    //http://localhost:5027/api/customers/{id}
    [HttpDelete]
    [Route("{id}")]
    public async Task<bool> Delete(int id)
    {
        bool result = await _service.Delete(id);
        return result;
    }

    //http://localhost:5027/api/customers/user/{id}
    [HttpGet]
    [Route("user/{id}")]
    public async Task<Customer> GetByUserId(int id)
    {
        var customer = await _service.GetByUserId(id);
        return customer;
    }
}
