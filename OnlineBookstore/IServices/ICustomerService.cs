using OnlineBookstore.Models;
using System.Security.Claims;

namespace OnlineBookstore.IServices
{
    public interface ICustomerService
    {
        ICollection<CustomerDTO> GetAll();
        CustomerDTO GetById(int id);
        void Create(RegisterCustomerDTO dto);
        string GenerateToken(LoginDTO loginDTO);
        void Update(int id, UpdateCustomerAboutDTO dto);
        void ChangePassword(int id, UpdateCustomerPasswordDTO dto);
    }
}
