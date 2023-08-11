using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionMvc.Models;
namespace SessionMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

   public IActionResult Index(){  
            // will store string ,integer and complex object in to 
            // session maintained inside distributed Cache
            // at server side
            //  HttpContext.Session.SetString("SessionKeyName","Dell computer");
            //  string computer =  HttpContext.Session.GetString("SessionKeyName");
            // Console.WriteLine(computer);
            string SessionKeyName="product";
            string SessionKeyAge="age";
            HttpContext.Session.SetString(SessionKeyName,"Dell computer");
            HttpContext.Session.SetInt32(SessionKeyAge, 45);
        
            return View();
        }

    public IActionResult Privacy(){
            ViewBag.data =HttpContext.Session.GetString("product");
            ViewBag.age=HttpContext.Session.GetInt32("age");
            
         return View();
        }



        public IActionResult QueryTest(){
            string city=string.Empty;
            string state=string.Empty;
            string name=string.Empty;
            name=HttpContext.Request.Query["name"];
            city=HttpContext.Request.Query["city"];
            state=HttpContext.Request.Query["state"];
            return Content("Query Test funcation is invoked...." + name + "  " + city + " "+ state );
        }

        public IActionResult  Students(){
            List<string> data=new List<string>();
            data.Add("Ravi");
            data.Add("Sameer");
            data.Add("Rajiv");
            data.Add("Pramod");
            var result=data.ToArray();
            return new JsonResult(result);
        }       

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
