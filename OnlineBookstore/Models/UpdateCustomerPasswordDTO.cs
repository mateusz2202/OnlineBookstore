using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class UpdateCustomerPasswordDTO
    {
        
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
