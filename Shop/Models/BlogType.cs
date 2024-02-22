using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class BlogType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
