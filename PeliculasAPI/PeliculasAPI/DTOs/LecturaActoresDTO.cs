
namespace PeliculasAPI.DTOs
{
    public class LecturaActoresDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime Nacimiento { get; set; }
        public string Foto { get; set; } = null!;
    }
}
