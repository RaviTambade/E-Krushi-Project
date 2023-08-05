using BIService.Models;

namespace BIService.Repositories.Interfaces;

public interface IBIRepository{
   Task<List<OrderChart>> GetCountByMonth(int year);
   Task<List<OrderChart>> OrderStatus(int year);

   Task<List<ProductSale>> GetProductReport(int year);
}