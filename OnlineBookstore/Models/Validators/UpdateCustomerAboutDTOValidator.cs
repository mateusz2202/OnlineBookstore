using FluentValidation;
using OnlineBookstore.Entities;

namespace OnlineBookstore.Models.Validators
{
    public class UpdateCustomerAboutDTOValidator : AbstractValidator<UpdateCustomerAboutDTO>
    {
        public UpdateCustomerAboutDTOValidator(OnlineBookstoreDbContext dbContext)
        {
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Customers.Any(x => x.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "Email is taken");
                }
            });
        }
    }
}
