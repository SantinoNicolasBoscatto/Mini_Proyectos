namespace PeliculasAPI.DTOs
{
    public class LecturaPeliculaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime Estreno { get; set; }
        public string Poster { get; set; } = null!;
    }
}
