using FluentValidation;
using OnlineBookstore.Entities;

namespace OnlineBookstore.Models.Validators
{
    public class UpdateCustomerPasswordDTOValidator : AbstractValidator<UpdateCustomerPasswordDTO>
    {
        public UpdateCustomerPasswordDTOValidator(OnlineBookstoreDbContext dbContext) 
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter the password");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Please enter the confirmation password");
           
        }
    }
}
