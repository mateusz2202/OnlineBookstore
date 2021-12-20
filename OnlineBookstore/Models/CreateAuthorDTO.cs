using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class CreateAuthorDTO
    {       
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        
    }
}
