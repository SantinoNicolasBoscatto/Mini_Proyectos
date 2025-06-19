using System.ComponentModel.DataAnnotations;
using WebApiActores.Validaciones;

namespace WebApiActores.DTOs
{
    public class CrearAutorDTO
    {
        [Required(ErrorMessage = "El Autor Requiere un nombre")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre del autor no puede ser mayor a {1}")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
