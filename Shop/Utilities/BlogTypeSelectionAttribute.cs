using Shop.Models;
using System.ComponentModel.DataAnnotations;
namespace Shop.Utilities
{
    public class BlogTypeSelectionAttribute : ValidationAttribute
    {
        private readonly int selectedTypeId;

        public BlogTypeSelectionAttribute(int selectedTypeId)
        {
            this.selectedTypeId = selectedTypeId;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Blog blog = (Blog)validationContext.ObjectInstance;
            
            if (blog.TypeId == 0)
            {
                return new ValidationResult("Please select a category");
            }

            return ValidationResult.Success;
        }
    }

}


