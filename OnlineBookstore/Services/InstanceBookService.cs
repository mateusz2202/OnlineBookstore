using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Entities;
using OnlineBookstore.Exceptions;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;
using System.Linq;

namespace OnlineBookstore.Services
{
    public class InstanceBookService : IInstanceBookService
    {
        private readonly OnlineBookstoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public InstanceBookService(OnlineBookstoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(CreateInstanceBookDTO dto)
        {
            var instanceBook=_mapper.Map<InstanceBook>(dto);
            instanceBook.ISBN=Guid.NewGuid().ToString();
            var publisher=_dbContext.Publishers.FirstOrDefault(x=>x.Id==dto.PublisherId);
            if (publisher==null) throw new CreateResourceException("publisher doesn't exist");
            else instanceBook.Publisher=publisher;
            var warehouse = _dbContext.Warehouses.FirstOrDefault(x => x.Id == dto.WarehouseId);
            if (warehouse == null) throw new CreateResourceException("warehouse doesn't exist");
            else instanceBook.Warehouse = warehouse;
           
            _dbContext.InstanceBooks.Add(instanceBook);
            _dbContext.SaveChanges();
        }

        public ICollection<InstanceBookDTO> GetAll()
        {
            var instanceBooks=_dbContext.InstanceBooks               
                .Include(a=>a.Publisher)
                .Include(a=>a.Book)
                .Include(a=>a.Book.BookCategories)
                .ThenInclude(a=>a.Category)
                .Include(a=>a.Book.AuthorBooks)
                .ThenInclude(a=>a.Author)
                .ToList();
            var instanceBooksDTO = _mapper.Map<List<InstanceBookDTO>>(instanceBooks);
            return instanceBooksDTO;
        }

        public InstanceBookDTO GetById(int id)
        {
            var instanceBook= _dbContext.InstanceBooks
                .Include(a => a.Publisher)
                .Include(a => a.Book)
                .Include(a => a.Book.BookCategories)
                .ThenInclude(a => a.Category)
                .Include(a => a.Book.AuthorBooks)
                .ThenInclude(a => a.Author)
                .FirstOrDefault(x=>x.Id == id);
            if (instanceBook == null) throw new NotFoundException("Not found Instance Book");
            var instanceBookDTO=_mapper.Map<InstanceBookDTO>(instanceBook);
            return instanceBookDTO;
        }
    }
}
