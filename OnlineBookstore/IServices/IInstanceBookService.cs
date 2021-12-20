using OnlineBookstore.Models;

namespace OnlineBookstore.IServices
{
    public interface IInstanceBookService
    {
        ICollection<InstanceBookDTO> GetAll();
        InstanceBookDTO GetById(int id);
        void Create(CreateInstanceBookDTO dto);
    }
}
