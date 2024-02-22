using Shop.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name field is required")]
        [DeniedValues("AAA", "BBB", ErrorMessage = "Invalid Name !")]

        [Length(4,10)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price field is required")]
        [Range(1, 10000)]
        [MaxPriceForCompany(10000)]    
        public float Price { get; set; }

        [Required(ErrorMessage = "Quantity field is required")]
        [ProductQuantity(0)]
        public int Quantity { get; set; } 

        public Boolean EnableSize { get; set; }

        [ProductCompanySelection(0)]
        public int CompanyId {  get; set; }
        [ForeignKey("CompanyId")]
        public Company? company { get; set; } // ? mean that can be null
    }
}

//_db as a service not normal object (.net convention)