
using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;
using E_krushiApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace E_krushiApp.Controllers;

[ApiController]
[Route("[controller]")]
public class SolutionController : ControllerBase
{


    private readonly ISolutionService _srv;

    public SolutionController(ISolutionService srv)
    {
        _srv = srv;
    }


    [HttpGet]
    [Route("getall")]
    public List<Solution> GetAll()
    {

        List<Solution> solutions = _srv.GetAll();

        return solutions;
    }

     [HttpGet]
    [Route("getbyid/{id}")]
    public Solution GetById(int id)
    {

        Solution solution = _srv.GetById(id);

        return solution;
    }


      [HttpPost]
    [Route("Insert")]
    public bool InsertSolution(Solution solution)
    {

        bool status = _srv.InsertSolution(solution);

        return status;
    }


     [HttpPut]
    [Route("update")]
    public bool UpdateSolution(Solution solution)
    {

    bool status = _srv.UpdateSolution(solution);

        return status;
    }



      [HttpDelete]
    [Route("Delete/{id}")]
    public bool DeleteSolution(int id)
    {

        bool status = _srv.DeleteSolution(id);

        return status;
    }
   



     

}
