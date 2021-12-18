namespace OnlineBookstore.Entities
{
    public class ShoppingBasket
    {
        public int Id { get; set; }       
        public virtual ICollection<InstanceBook> InstanceBooks { get; set; }
        public virtual Order Order { get; set; }

    }
}
