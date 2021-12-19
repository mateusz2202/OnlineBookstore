using OnlineBookstore.Entities;

namespace OnlineBookstore.IServices
{
    public interface ICustomerService
    {
        ICollection<Customer> GetAll();
    }
}
