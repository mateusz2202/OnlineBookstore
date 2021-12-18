using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks{ get; set; }

    }
}
