using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class RegisterCustomerDTO
    {
        [Required]
        [MaxLength(30)]
        public string FisrtName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        [Required]
        [MinLength(4)]        
        public string Password{ get; set; }        
        [Compare("Password")]
        public string ConfirmPassword{ get; set; }
        [Required]
        public int RoleId { get; set; }

    }
}
