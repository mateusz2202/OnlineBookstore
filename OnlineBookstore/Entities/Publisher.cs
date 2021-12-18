using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]     
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; } 
        [Url]
        public string? Url { get; set; }     

        public virtual ICollection<InstanceBook> InstanceBooks { get; set; }
    }
}
