using PeliculasAPI.Controllers;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Entidades
{
    public class Actor : IId
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; } = null!;
        [Required]
        public DateTime Nacimiento { get; set; }
        public string Foto { get; set; } = null!;
        public List<ActoresPeliculas>? ListPeliculas { get; set; }
    }
}
