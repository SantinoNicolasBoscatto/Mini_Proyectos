namespace PeliculasAPI.DTOs
{
    public class RespuestaAutenticacionDTO
    {
        public string Token { get; set; } = null!;
        public DateTime Exp { get; set; }
    }
}
