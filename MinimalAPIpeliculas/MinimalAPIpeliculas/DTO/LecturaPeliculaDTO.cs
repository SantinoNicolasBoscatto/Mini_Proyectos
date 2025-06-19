using MinimalAPIpeliculas.Entitys;

namespace MinimalAPIpeliculas.DTO
{
    public class LecturaPeliculaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string? Poster { get; set; }
        public List<Comentario> ListaComentarios { get; set; } = new List<Comentario>();
        public List<LecturaGeneroDTO> ListaLecturaGenero { get; set; } = new List<LecturaGeneroDTO>();
        public List<ActorPeliculaDTO> ListaLecturaActor { get; set; } = new List<ActorPeliculaDTO>();
    }
}
