using Shop.Models;
using System.ComponentModel.DataAnnotations;
namespace Shop.Utilities
{
    public class ProductCompanySelectionAttribute : ValidationAttribute
    {
        private readonly int selectedCompanyId;

        public ProductCompanySelectionAttribute(int selectedCompanyId)
        {
            this.selectedCompanyId = selectedCompanyId;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product product = (Product)validationContext.ObjectInstance;

            if (product.CompanyId == 0)
            {
                return new ValidationResult("Please select the company");
            }

            return ValidationResult.Success;
        }
    }
}
