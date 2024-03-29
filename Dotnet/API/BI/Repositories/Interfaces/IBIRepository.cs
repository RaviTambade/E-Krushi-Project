using Transflower.EKrushi.BIService.Models;

namespace Transflower.EKrushi.BIService.Repositories.Interfaces;

public interface IBIRepository{
   Task<List<OrderChart>> GetCountByMonth(int year);
   
   Task<List<OrderChart>> OrderStatus(int year);

   Task<List<ProductSale>> GetProductReport(int year);

   Task<List<CustomerReport>> GetCustomerReport(int custId);

   Task<List<SMEReport>> GetSMEReport(int year);

   Task<List<OrderChart>> GetTotalRevenue(int year);

   Task<List<OrderChart>> GetWeeklyOrders(int year);

   Task<List<OrderChart>> GetYearlyOrders();

   Task<List<OrderChart>> GetYearlySMEPerformance();
}