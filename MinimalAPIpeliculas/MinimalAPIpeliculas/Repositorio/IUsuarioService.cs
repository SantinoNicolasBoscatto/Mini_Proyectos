using Microsoft.AspNetCore.Identity;

namespace MinimalAPIpeliculas.Repositorio
{
    public interface IUsuarioService
    {
        Task<IdentityUser?> ObtenerUsuario();
    }
}