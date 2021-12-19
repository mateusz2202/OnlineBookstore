using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Entities;
using OnlineBookstore.IServices;

namespace OnlineBookstore.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly OnlineBookstoreDbContext _dbContext;

        public OrderService(ILogger<OrderService> logger, OnlineBookstoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public ICollection<Order> GetAll()
        {
            var orders = _dbContext.Orders             
                .ToList();
            return orders;
        }
    }
}
