using E_krushiApp.Models;
using E_krushiApp.Repository.Interface;

namespace E_krushiApp.Services.Interface;
public interface IConsultingService : IConsultingRepository
{
    Question GetById(int id);
}