using MinimalAPIpeliculas.Repositorio;

namespace MinimalAPIpeliculas.Entitys
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string? Poster { get; set; }
        public List<Comentario> ListaComentarios { get; set; } = new List<Comentario>();
        public List<GeneroPelicula> ListaGenerosPeliculas { get; set; } = new List<GeneroPelicula>();
        public List<ActoresPeliculas> ListaPeliculaActor { get; set; } = new List<ActoresPeliculas>();

    }
}
