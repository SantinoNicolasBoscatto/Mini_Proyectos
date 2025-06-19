using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Validaciones
{
    public class PesoArchivoValidacionAttribute : ValidationAttribute
    {
        private readonly int pesoMaximo;

        public PesoArchivoValidacionAttribute(int pesoMaximo)
        {
            this.pesoMaximo = pesoMaximo;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null) return ValidationResult.Success;

            IFormFile? file = value as IFormFile;
            if(file == null ) return ValidationResult.Success;
            if (file.Length > pesoMaximo * 1024 * 1024) return new ValidationResult($"El Peso del Archivo no debe ser mayor a {pesoMaximo}Mb");
            return ValidationResult.Success;
        }
    }
}
