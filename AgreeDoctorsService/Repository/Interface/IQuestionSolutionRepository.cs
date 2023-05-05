using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IQuestionSolutionRepository{

    public List<QuestionSolution> GetAll();

    public QuestionSolution GetById(int id);

    public bool InsertQuestionSolution(QuestionSolution questionSolution);
     
    public bool UpdateQuestionSolution(QuestionSolution questionSolution);
    
    public bool DeleteQuestionSolution(int id);

}