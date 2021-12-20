using OnlineBookstore.Entities;
using OnlineBookstore.Models;

namespace OnlineBookstore.IServices
{
    public interface IOrderService
    {
        ICollection<OrderDTO> GetAll();
        OrderDTO GetById(int id);
    }
}
