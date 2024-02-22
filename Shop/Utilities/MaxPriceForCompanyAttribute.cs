using Shop.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.Utilities
{
    public class MaxPriceForCompanyAttribute : ValidationAttribute { 

        private readonly float _maxPrice;
        public MaxPriceForCompanyAttribute(float maxPrice)
        {
            _maxPrice = maxPrice;   
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            Product product = (Product)validationContext.ObjectInstance;  

            float price;

            if (!float.TryParse(value.ToString(), out price))
            {
                return new ValidationResult("Enter int value");
            }

            if (product.CompanyId == 1 && price > _maxPrice)
            {
                return new ValidationResult("Adidas price less than " + _maxPrice.ToString());
            }

            return ValidationResult.Success;
        }
    }
    
    
}
