using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public int? AddressId { get; set; }
        public virtual ICollection<InstanceBook> InstanceBooks { get; set; }
    }
}
