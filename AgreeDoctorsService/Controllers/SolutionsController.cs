
using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class SolutionsController : ControllerBase
{


    private readonly ISolutionService _srv;

    public SolutionsController(ISolutionService srv)
    {
        _srv = srv;
    }


    [HttpGet]
    [Route("Solutions")]
    public List<Solution> GetAll()
    {

        List<Solution> solutions = _srv.GetAll();

        return solutions;
    }

    [HttpGet]
    [Route("Solutions/{id}")]
    public Solution GetById(int id)
    {

        Solution solution = _srv.GetById(id);

        return solution;
    }


      [HttpPost]
    [Route("Insert")]
    public bool Insert(Solution solution)
    {

        bool status = _srv.Insert(solution);

        return status;
    }


     [HttpPut]
    [Route("update")]
    public bool Update(Solution solution)
    {

    bool status = _srv.Update(solution);

        return status;
    }



      [HttpDelete]
    [Route("Delete/{id}")]
    public bool Delete(int id)
    {

        bool status = _srv.Delete(id);

        return status;
    }
   



     

}
