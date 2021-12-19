using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Entities;
using OnlineBookstore.IServices;

namespace OnlineBookstore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly OnlineBookstoreDbContext _dbContext;

        public CustomerService(ILogger<CustomerService> logger, OnlineBookstoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public ICollection<Customer> GetAll()
        {
            var result = _dbContext.Customers
                .Include(a=>a.Address)
                .Include(a=>a.ShoppingBaskets)
                .ToList();
            return result;
        }
    }
}
