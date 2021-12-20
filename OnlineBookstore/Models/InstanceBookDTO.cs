using OnlineBookstore.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class InstanceBookDTO
    {
        public int Id { get; set; }      
        public string ISBN { get; set; }    
        public DateTime ReleaseDate { get; set; } 
        public decimal Price { get; set; }
        public string CoverUrl { get; set; }
        public string PublisherName { get; set; }   
        public string Title { get; set; }  
        public string Language { get; set; } 
        public List<CategoryDTO> Categories { get; set; }
        public List<AuthorDTO> Authors { get; set; }
      
    }
}
