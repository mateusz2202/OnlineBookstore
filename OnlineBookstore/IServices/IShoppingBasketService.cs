using OnlineBookstore.Entities;

namespace OnlineBookstore.IServices
{
    public interface IShoppingBasketService
    {
        ICollection<ShoppingBasket> GetAll();
    }
}
