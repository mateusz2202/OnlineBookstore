using OnlineBookstore.Entities;
using OnlineBookstore.IServices;

namespace OnlineBookstore.Services
{
    public class ShoppingBasketService:IShoppingBasketService
    {
        private readonly OnlineBookstoreDbContext _dbContext;

        public ShoppingBasketService(OnlineBookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<ShoppingBasket> GetAll()
        {
            var result=_dbContext.ShoppingBaskets.ToList();
            return result;
        }

    }
}
