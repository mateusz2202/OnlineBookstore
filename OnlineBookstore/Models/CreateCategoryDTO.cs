using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class CreateCategoryDTO
    {    
        [Required]
        public string Name { get; set; }
    }
}
