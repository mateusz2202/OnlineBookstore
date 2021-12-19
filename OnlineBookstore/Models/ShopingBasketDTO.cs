using OnlineBookstore.Entities;

namespace OnlineBookstore.Models
{
    public class ShopingBasketDTO
    {
        public int Id { get; set; }
        public virtual List<InstanceBook> InstanceBooks { get; set; }
        public virtual Order? Order { get; set; }

        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
