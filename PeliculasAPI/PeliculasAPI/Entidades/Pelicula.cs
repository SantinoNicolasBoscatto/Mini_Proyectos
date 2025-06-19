using PeliculasAPI.Controllers;

namespace PeliculasAPI.Entidades
{
    public class Pelicula : IId
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime Estreno { get; set; }
        public string Poster { get; set; } = null!;
        public List<ActoresPeliculas>? ListActores { get; set; }
        public List<GenerosPeliculas>? ListGeneros { get; set; }
        public List<SalasPeliculas> ListSalas { get; set; } = null!;

    }
}
