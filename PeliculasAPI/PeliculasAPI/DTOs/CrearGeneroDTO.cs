using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class CrearGeneroDTO
    {
        [Required]
        public string Nombre { get; set; } = null!;
    }
}
