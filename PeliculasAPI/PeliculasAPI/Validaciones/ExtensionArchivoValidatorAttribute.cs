using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PeliculasAPI.Validaciones
{
    public class ExtensionArchivoValidatorAttribute : ValidationAttribute
    {
        private readonly string[]? extensiones;

        public ExtensionArchivoValidatorAttribute(GrupoExtensionArchivo grupoExtensionArchivo)
        {
            if (grupoExtensionArchivo == GrupoExtensionArchivo.Imagen)
            {
                extensiones = new string[] { "image/jpeg", "image/png", "image/gif" };
            }
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            IFormFile? file = value as IFormFile;
            if (file == null) return ValidationResult.Success;

            if(!extensiones!.Contains(file.ContentType))
            {
                return new ValidationResult($"El Tipo del Archivo debe ser de los siguientes: {string.Join(", ", extensiones!)}");
            }

            return ValidationResult.Success;
        }
    }
}
