using Microsoft.IdentityModel.Tokens;
using MinimalAPIpeliculas.Utilidades;

namespace MinimalAPIpeliculas.DTO
{
    public class PaginacionDTO
    {
        private const int pagValorInicial = 1;
        private const int recordsValorInicial = 10;


        public int Pagina { get; set; } = pagValorInicial;
        private int recordsPorPagina = recordsValorInicial;

        private readonly int recordsPorPaginaMax = 50;
        public int RecordsPorPagina
        {
            get{return recordsPorPagina;}
            set{recordsPorPagina = (value > recordsPorPaginaMax) ? recordsPorPaginaMax : value;}
        }

        public static ValueTask<PaginacionDTO> BindAsync(HttpContext context)
        {
            var pagina = context.ExtraerValorPorDefecto(nameof(Pagina), pagValorInicial);
            var records = context.ExtraerValorPorDefecto(nameof(recordsPorPagina), recordsValorInicial);
            var result = new PaginacionDTO { Pagina = pagina, recordsPorPagina = records };
            return ValueTask.FromResult(result);
        }
    }
}
