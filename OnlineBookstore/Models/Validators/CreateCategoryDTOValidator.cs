using FluentValidation;
using OnlineBookstore.Entities;

namespace OnlineBookstore.Models.Validators
{
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        
        public CreateCategoryDTOValidator(OnlineBookstoreDbContext dbContext)
        {
            
            RuleFor(c => c.Name).NotEmpty()
                .Custom((value, context) =>
                {
                    var categoryIsInBase = dbContext.Categories.Any(x => x.Name.ToLower() == value.ToLower());
                    if (categoryIsInBase)
                    {
                        context.AddFailure("Category", "There is already such a category");
                    }
                });
        }
       
    }
}
