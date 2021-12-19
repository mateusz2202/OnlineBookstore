using OnlineBookstore.Models;

namespace OnlineBookstore.IServices
{
    public interface ICustomerService
    {
        ICollection<CustomerDTO> GetAll();
        CustomerDTO GetById(int id);
        void Create(RegisterCustomerDTO dto);
        string GenerateToken(LoginDTO loginDTO);
    }
}
