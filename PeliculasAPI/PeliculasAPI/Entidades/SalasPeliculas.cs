namespace PeliculasAPI.Entidades
{
    public class SalasPeliculas
    {
        public int SalaDeCineId { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
        public SalasDeCine SalaDeCine { get; set; } = null!;
    }
}
