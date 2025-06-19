using MinimalAPIpeliculas.DTO;

namespace MinimalAPIpeliculas.Utilidades
{
    public static class IQueyableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> query, PaginacionDTO paginacionDTO)
        {
            return query
                   .Skip((paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorPagina)
                   .Take(paginacionDTO.RecordsPorPagina);
        }
    }
}
