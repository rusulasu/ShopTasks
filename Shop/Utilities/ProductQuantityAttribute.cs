using Shop.Models;
using System.ComponentModel.DataAnnotations;
namespace Shop.Utilities
{
    public class ProductQuantityAttribute : ValidationAttribute
    {
        private readonly int productQuantity;

        public ProductQuantityAttribute(int productQuantity)
        {
            this.productQuantity = productQuantity;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product product = (Product)validationContext.ObjectInstance;

            if (product.Quantity == 0)
            {
                return new ValidationResult("Please enter a valid product quantity");
            }

            return ValidationResult.Success;
        }
    }
}
