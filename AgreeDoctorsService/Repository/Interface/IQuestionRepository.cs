using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IQuestionRepository{

    public List<Question> GetAll();

    public Question GetById(int id);

    public bool InsertDoctor(Question question);
     
    public bool UpdateDoctor(Question question);
    
    public bool DeleteDoctor(int id);

}