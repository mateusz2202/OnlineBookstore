namespace OnlineBookstore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }        
        public DateTime? DateFinish { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public int OrderStatusId { get; set; }

        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public virtual ShoppingBasket ShoppingBasket { get; set; }       
    }
}
