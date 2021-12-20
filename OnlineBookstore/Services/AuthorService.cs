using AutoMapper;
using OnlineBookstore.Entities;
using OnlineBookstore.Exceptions;
using OnlineBookstore.IServices;
using OnlineBookstore.Models;

namespace OnlineBookstore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly OnlineBookstoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorService(OnlineBookstoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(CreateAuthorDTO dto)
        {
            var author=_mapper.Map<Author>(dto);
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var author=_dbContext.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null) throw new NotFoundException("Author not found");
            var authorIsUsed = _dbContext.AuthorBooks.Any(a => a.AuthorID == id);
            if(authorIsUsed) throw new ResourceUsedException("Author is used");
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();           
        }

        public ICollection<AuthorDTO> GetAll()
        {
            var authors = _dbContext.Authors.ToList();
            var auhorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return auhorsDTO;
        }

        public AuthorDTO GetById(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null) throw new NotFoundException("Author not found");
            var authorDTO= _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public void Update(int id, CreateAuthorDTO dto)
        {
            var author=_dbContext.Authors.FirstOrDefault(x=>x.Id == id);
            if (author == null) throw new NotFoundException("Author not found");
            author.FirstName=dto.FirstName;
            author.LastName=dto.LastName;
            _dbContext.Authors.Update(author);
            _dbContext.SaveChanges();           
        }
    }
}
