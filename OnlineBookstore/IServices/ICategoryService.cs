using OnlineBookstore.Models;

namespace OnlineBookstore.IServices
{
    public interface ICategoryService
    {
        ICollection<CategoryDTO> GetAll();
        void Create(CreateCategoryDTO dto);
        void Update(int id,CreateCategoryDTO dto);
        void Delete(int id);
    }
}
