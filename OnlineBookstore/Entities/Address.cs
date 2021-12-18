using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string City  { get; set; }
        [Required]
        [MaxLength(40)]
        public string Street  { get; set; }
        [Required]
        [MaxLength(40)]
        public string AddressLine { get; set; }
        [Required]
        [MaxLength(15)]
        public string PostalCode  { get; set; }
    }
}