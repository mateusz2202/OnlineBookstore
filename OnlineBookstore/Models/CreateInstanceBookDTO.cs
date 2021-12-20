using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class CreateInstanceBookDTO
    {   

        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string CoverUrl { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
