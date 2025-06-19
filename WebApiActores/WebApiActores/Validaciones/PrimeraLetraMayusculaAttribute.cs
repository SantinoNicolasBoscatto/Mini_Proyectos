using System.ComponentModel.DataAnnotations;

namespace WebApiActores.Validaciones
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) return ValidationResult.Success;

            var r = value.ToString()[0].ToString() == value.ToString().ToUpper()[0].ToString() ? true : false;
            if (r) return ValidationResult.Success;

            return new ValidationResult("La primera letra debe ser mayuscula");
        }
    }
}
