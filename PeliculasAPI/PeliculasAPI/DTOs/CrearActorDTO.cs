using PeliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class CrearActorDTO
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; } = null!;
        [Required]
        public DateTime Nacimiento { get; set; }
        [PesoArchivoValidacionAttribute(pesoMaximo: 25)]
        [ExtensionArchivoValidator(GrupoExtensionArchivo.Imagen)]
        public IFormFile Foto { get; set; } = null!;
        public List<int>? ListaPeliculasIds { get; set; } 
    }
}
