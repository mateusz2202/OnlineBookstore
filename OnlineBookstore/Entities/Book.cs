using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(40)]
        public string Language { get; set; }
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }

        public virtual ICollection<InstanceBook> InstanceBooks { get; set; }
    }
}
