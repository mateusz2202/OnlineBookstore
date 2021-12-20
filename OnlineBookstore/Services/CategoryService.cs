using AutoMapper;
using OnlineBookstore.Entities;
using OnlineBookstore.Exceptions;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;

namespace OnlineBookstore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly OnlineBookstoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(OnlineBookstoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(CreateCategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category=_dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) throw new NotFoundException("Category not found");
            var categoryIsUsed=_dbContext.BookCategories.Any(a=>a.CategoryId == id);
            if (categoryIsUsed) throw new ResourceUsedException("Category is used");
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public ICollection<CategoryDTO> GetAll()
        {
            var categories = _dbContext.Categories.ToList();
            var categoriesDTO=_mapper.Map<List<CategoryDTO>>(categories);
            return categoriesDTO;
        }

        public void Update(int id, CreateCategoryDTO dto)
        {
            var category=_dbContext.Categories.FirstOrDefault(x=>x.Id == id);
            if (category == null) throw new NotFoundException("Category not found");
            category.Id= id;
            category.Name= dto.Name;
            _dbContext.Update(category);
            _dbContext.SaveChanges();       
        }
    }
}
