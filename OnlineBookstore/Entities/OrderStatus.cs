using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string NameStatus { get; set; }
    }
}
