using MinimalAPIpeliculas.Utilidades;

namespace MinimalAPIpeliculas.DTO
{
    public class PeliculasFiltrarDTO
    {
        public int Pagina { get; set; }
        public int RecordsPorPagina { get; set; }
        public PaginacionDTO PaginacionDTO { get { return new PaginacionDTO() { Pagina = Pagina, RecordsPorPagina = RecordsPorPagina }; } }

        public string? Titulo { get; set; }
        public int GeneroId { get; set; }
        public bool EnCines { get; set; }
        public bool ProximosEstrenos { get; set; }
        public string? CampoOrdenar { get; set; }
        public bool OrdenAscendente { get; set; } = true;


        public static ValueTask<PeliculasFiltrarDTO> BindAsync(HttpContext httpContext)
        {
            var pagina = httpContext.ExtraerValorPorDefecto(nameof(Pagina), 1);
            var records = httpContext.ExtraerValorPorDefecto(nameof(RecordsPorPagina), 10);
            var generoId = httpContext.ExtraerValorPorDefecto(nameof(GeneroId), 0);
            var titulo = httpContext.ExtraerValorPorDefecto(nameof(Titulo), string.Empty);
            var enCines = httpContext.ExtraerValorPorDefecto(nameof(EnCines), false);
            var estrenos = httpContext.ExtraerValorPorDefecto(nameof(ProximosEstrenos), false);
            var campoOrdenar = httpContext.ExtraerValorPorDefecto(nameof(CampoOrdenar), string.Empty);
            var ordenAscendente = httpContext.ExtraerValorPorDefecto(nameof(OrdenAscendente), true);


            var resultado = new PeliculasFiltrarDTO
            {
                Pagina = pagina,
                RecordsPorPagina = records,
                GeneroId = generoId,
                Titulo = titulo,
                EnCines = enCines,
                ProximosEstrenos = estrenos,
                CampoOrdenar = campoOrdenar,
                OrdenAscendente = ordenAscendente
            };

            return ValueTask.FromResult(resultado);

        }

    }
}
