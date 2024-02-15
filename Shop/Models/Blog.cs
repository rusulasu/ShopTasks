using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
        
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public BlogType blog_type { get; set; } 
    }
}
