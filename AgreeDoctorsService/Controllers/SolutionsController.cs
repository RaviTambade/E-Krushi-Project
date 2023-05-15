
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
    [Route("getallSolutions")]
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
    [Route("InsertSolution")]
    public bool InsertSolution(Solution solution)
    {

        bool status = _srv.InsertSolution(solution);

        return status;
    }


     [HttpPut]
    [Route("updateSolution")]
    public bool UpdateSolution(Solution solution)
    {

    bool status = _srv.UpdateSolution(solution);

        return status;
    }



      [HttpDelete]
    [Route("DeleteSolution/{id}")]
    public bool DeleteSolution(int id)
    {

        bool status = _srv.DeleteSolution(id);

        return status;
    }
   



     

}
