using OnlineBookstore.Entities;

namespace OnlineBookstore.IServices
{
    public interface IOrderService
    {
        ICollection<Order> GetAll();
    }
}
