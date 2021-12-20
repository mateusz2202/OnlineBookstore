using FluentValidation;
using OnlineBookstore.Entities;

namespace OnlineBookstore.Models.Validators
{
    public class CreateAuthorDTOValidator : AbstractValidator<CreateAuthorDTO>
    {
        private readonly OnlineBookstoreDbContext _dbContext;
        public CreateAuthorDTOValidator(OnlineBookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(x => x).Must(x => !UniqueAuthor(x.FirstName, x.LastName)).WithMessage("Such author already exists");            
        }
        private bool UniqueAuthor(string firstName, string lastName)=> _dbContext.Authors.Any(x => x.FirstName.ToLower() == firstName.ToLower() && x.LastName.ToLower() == lastName.ToLower());
      
    }
}
