namespace EFCorePeliculas.DTO
{
    public class PeliculaDTO
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public ICollection<GeneroDTO> GenerosCollection { get; set; } = new List<GeneroDTO>();
        public ICollection<ActoresDTO> ActoresCollection { get; set; }
        public ICollection<CineDTO> CineCollection { get; set; }
    }
}
