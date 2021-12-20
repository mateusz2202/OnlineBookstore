namespace OnlineBookstore.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime? DateFinish { get; set; }
        public string OrderStatus { get; set; }                
        public int OrderByCustomerId { get; set; }
      
    }
}
