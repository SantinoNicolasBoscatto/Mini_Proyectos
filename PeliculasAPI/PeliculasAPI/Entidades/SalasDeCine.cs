using NetTopologySuite.Geometries;
using PeliculasAPI.Controllers;

namespace PeliculasAPI.Entidades
{
    public class SalasDeCine : IId
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public Point Ubicacion { get; set; } = null!;
        public List<SalasPeliculas> ListPeliculas { get; set; } = null!;
    }
}
