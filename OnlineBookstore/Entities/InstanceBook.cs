using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Entities
{
    public class InstanceBook
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string ISBN { get; set; }
        [Required]
        [MaxLength(150)]
        public DateTime ReleaseDate { get; set; }
        [Required]        
        public decimal Price { get; set; }

        public string CoverUrl { get; set; }

        public virtual Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public virtual Book Book { get; set; }
        public int BookId { get; set; }
        public virtual Warehouse Warehouse{ get; set; }
        public int WarehouseId { get; set; }
        public virtual ShoppingBasket ShoppingBasket { get; set; }
        public int ShoppingBasketId { get; set;}
      


    }
}
