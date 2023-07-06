using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IQuestionRepository{

    public List<Question> GetAll();

    public Question GetById(int id);

    public bool Insert(Question question);
     
    public bool Update(Question question);
    
    public bool Delete(int id);

}