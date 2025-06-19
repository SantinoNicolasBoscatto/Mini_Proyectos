namespace WebApiActores.Entitys
{
    public class Libro
    {
        public int Id { get; set; }
        public string NombreLibro { get; set; }
        public List<AutorLibro> ListaAutoresLibros { get; set; }
        public List<Comentario> ListaComentarios { get; set; }
    }
}
