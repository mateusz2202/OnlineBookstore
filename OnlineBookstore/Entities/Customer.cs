using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
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
        public string? PasswordHash { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }

        public virtual Role Role { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
       
    }
}
