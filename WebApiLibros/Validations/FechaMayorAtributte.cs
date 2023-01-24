using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibros.Validations
{
    public class FechaMayorAtributte:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(Convert.ToDateTime(value).Year > 1950)
            {
            return ValidationResult.Success;

            }
                return new ValidationResult("Solo fechas mayores a 01/01/1950");
        }
    }
}
