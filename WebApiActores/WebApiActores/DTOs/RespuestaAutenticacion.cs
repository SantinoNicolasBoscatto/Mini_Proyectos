namespace WebApiActores.DTOs
{
    public class RespuestaAutenticacion
    {
        public string Token { get; set; }
        public DateTime Exp { get; set; }
    }
}
