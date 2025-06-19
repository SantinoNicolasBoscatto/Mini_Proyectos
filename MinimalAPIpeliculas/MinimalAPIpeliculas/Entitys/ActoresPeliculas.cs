namespace MinimalAPIpeliculas.Entitys
{
    public class ActoresPeliculas
    {
        public int ActorId { get; set; }
        public int PeliculaId { get; set; }
        public Actor Actor { get; set; } = null!;
        public Pelicula Pelicula { get; set; } = null!;
        public int Orden { get; set; }
        public string Personaje { get; set; } = null!;
    }
}
