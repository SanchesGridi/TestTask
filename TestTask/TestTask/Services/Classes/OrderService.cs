using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Classes
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<OrderService> logger;

        public OrderService(ApplicationDbContext context, ILogger<OrderService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<Order> GetOrder()
        {
            try
            {
                var orders = await context.Orders.ToListAsync();
                var order = orders.MaxBy(x => x.Quantity * x.Price);
  
                return order!;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<List<Order>> GetOrders()
        {
            try
            {
                return await context.Orders.Where(o => o.Quantity > 10).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
