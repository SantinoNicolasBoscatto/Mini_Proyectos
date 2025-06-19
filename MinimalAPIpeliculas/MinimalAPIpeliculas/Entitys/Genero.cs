namespace MinimalAPIpeliculas.Entitys
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public List<GeneroPelicula> ListaGenerosPeliculas { get; set; } = new List<GeneroPelicula>();
    }
}
