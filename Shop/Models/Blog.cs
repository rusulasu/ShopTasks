using Shop.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Title field is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content field is required")]
        public string Content { get; set; }


        [BlogTypeSelection(0)]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public BlogType? blog_type { get; set; } 
    }
}
