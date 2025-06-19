namespace EFCorePeliculas.Entitys
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterURL { get; set; }
        public List<Genero> GenerosHash { get; set; }
        public ICollection<SalaDeCine> SalaDeCineHash { get; set; }
        public ICollection<PeliculaActor> PeliculaActorHash { get; set; }

    }
}
