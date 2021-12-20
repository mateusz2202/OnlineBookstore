using OnlineBookstore.Models;

namespace OnlineBookstore.IServices
{
    public interface IAuthorService
    {
        ICollection<AuthorDTO> GetAll();
        void Create(CreateAuthorDTO dto);
        void Update(int id, CreateAuthorDTO dto);
        void Delete(int id);
        AuthorDTO GetById(int id);
    }
}
