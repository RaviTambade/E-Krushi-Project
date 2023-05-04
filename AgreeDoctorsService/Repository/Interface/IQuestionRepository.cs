using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IQuestionRepository{

    public List<Question> GetAll();

    public Question GetById(int id);

    public bool InsertQuestion(Question question);
     
    public bool UpdateQuestion(Question question);
    
    public bool DeleteQuestion(int id);

}