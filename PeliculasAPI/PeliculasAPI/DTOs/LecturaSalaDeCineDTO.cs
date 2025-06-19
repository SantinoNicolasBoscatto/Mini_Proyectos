namespace PeliculasAPI.DTOs
{
    public class LecturaSalaDeCineDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
