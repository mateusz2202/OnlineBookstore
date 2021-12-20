using FluentValidation;
using OnlineBookstore.Entities;

namespace OnlineBookstore.Models.Validators
{
    public class RegisterCustomerDTOValidator : AbstractValidator<RegisterCustomerDTO>
    {
        public RegisterCustomerDTOValidator(OnlineBookstoreDbContext dbContext)
        {
            RuleFor(x => x.Email).Custom((value, context) =>
              {                  
                  var emailInUse = dbContext.Customers.Any(x => x.Email == value);
                  if (emailInUse)
                  {
                      context.AddFailure("Email", "Email is taken");
                  }
              });
            RuleFor(x => x.RoleId).NotEmpty();
            RuleFor(x=>x.DateOfBirth).NotEmpty();
        }
    }
}
