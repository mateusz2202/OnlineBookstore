namespace OnlineBookstore.Entities
{
    public class AuthorBook
    {       
        public virtual Book Book { get; set; }
        public int BookId { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorID { get; set; }
    }
}
