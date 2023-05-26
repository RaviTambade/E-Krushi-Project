using E_krushiApp.Models;
namespace E_krushiApp.Repository.Interface;
public interface IConsultingRepository{

    Task<List<Question>> Questions();
    Task<Question> Question(int id);
    Task<List<Answer>> Answers(); 
    public Task<List<SubjectMatterExpert>> Experts();
    public Task<SubjectMatterExpert> Expert(int id);
    
    Task<List<Question>> Category(int id);
    
}