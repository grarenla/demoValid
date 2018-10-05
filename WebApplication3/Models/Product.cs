using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication3.Models
{
    public class Product: IValidatableObject
    {
        public Product()
        {
        }

        [Required] public int Id { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 3)]
//        [CheckSex]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        
        public string Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Product p = (Product)validationContext.ObjectInstance;

            if (p.Name.Contains("sex") || p.Name.Contains("porn"))
            {
                yield return new ValidationResult(
                    $"Chua noi dung nhay cam",
                    new[] { "Name" });
            }
        }
    }

//    public class CheckSexAttribute : ValidationAttribute
//    {
//       
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            Product p = (Product) validationContext.ObjectInstance;
//
//            if (p.Name.Contains("sex") || p.Name.Contains("porn"))
//            {
//                return new ValidationResult("Chua noi dung nhay cam");
//            }
//
//            return ValidationResult.Success;
//        }
//
//  
//    }
}