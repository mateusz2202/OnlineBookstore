using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class UpdateCustomerAboutDTO
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
        public string City { get; set; }
        public string Street { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
    }
}
