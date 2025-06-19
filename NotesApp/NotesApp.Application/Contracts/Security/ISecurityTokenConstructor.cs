using NotesApp.Domain.Users;

namespace NotesApp.Application.Contracts.Security
{
    public interface ISecurityTokenConstructor
    {
        Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario cred);
    }
}
