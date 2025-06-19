using WebApiActores.Entitys;

namespace WebApiActores.DTOs
{
    public class LecturaLibroDTO
    {
        public int Id { get; set; }
        public string NombreLibro { get; set; }
        public List<LecturaComentarioDTO> ListaComentarios { get; set; }
        public List<LecturaAutorDTO> ListaAutores { get; set; }
    }
}
