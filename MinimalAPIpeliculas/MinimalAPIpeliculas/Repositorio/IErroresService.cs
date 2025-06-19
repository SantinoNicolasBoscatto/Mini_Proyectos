using MinimalAPIpeliculas.Entitys;

namespace MinimalAPIpeliculas.Repositorio
{
    public interface IErroresService
    {
        Task Crear(Error error);
    }
}