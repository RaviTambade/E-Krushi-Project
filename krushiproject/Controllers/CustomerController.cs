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

//     public JsonResult GetCustomer(int id)
//     {
//         var customer = _srv.GetCustomer(id);
//         return Json(customer);
//     }

//     [HttpPost]
//      public JsonResult Insert([FromBody] Customer customer)
//    {    
//         bool result =_srv.InsertCustomer(customer);
//         return Json(result);
//    }
  
//    [HttpPut]
//    public JsonResult Update([FromBody] Customer customer)
//    {
//         bool result =_srv.UpdateCustomer(customer);
//         return Json(result);
//    }
   
//    [HttpDelete]
//    public JsonResult Delete(int id)
//    {
//     bool result = _srv.DeleteCustomer(id);
//     return Json(result);
//    }


    
   
}
