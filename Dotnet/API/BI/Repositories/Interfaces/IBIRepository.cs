using BIService.Models;

namespace BIService.Repositories.Interfaces;

public interface IBIRepository{
   Task<List<OrderChart>> GetCountByMonth(int year);
   
   Task<List<OrderChart>> OrderStatus(int year);

   Task<List<ProductSale>> GetProductReport(int year);

   Task<List<CustomerReport>> GetCustomerReport(int custId);

   Task<List<SMEReport>> GetSMEReport(int year);

   Task<List<OrderChart>> GetTotalRevenue(int year);

   Task<List<OrderChart>> GetMonthlyOrders(int year);
}