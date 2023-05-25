using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IQuestionSolutionRepository{

    public List<QuestionSolution> GetAll();

    public QuestionSolution GetById(int id);

    public bool Insert(QuestionSolution solution);
     
    public bool Update(QuestionSolution solution);
    
    public bool Delete(int id);

}