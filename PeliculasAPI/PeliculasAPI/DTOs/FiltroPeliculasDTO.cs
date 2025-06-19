namespace PeliculasAPI.DTOs
{
    public class FiltroPeliculasDTO
    {
        public int Pagina { get; set; } = 1;
        public int RecordsPorPagina { get; set; } = 10;
        public PaginacionDTO PaginacionDTO 
        {
            get
            {
                return new PaginacionDTO { RecordsPorPagina = this.RecordsPorPagina, Pagina = Pagina };
            }
        }
        public string? Titulo { get; set; }
        public int GeneroId { get; set; }
        public bool EnCines { get; set; }
        public bool Estrenos { get; set; }

        public string? CampoOrdenar { get; set; }
        public bool Ascendente { get; set; } = true;
    }
}
