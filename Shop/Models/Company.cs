using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Company
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
