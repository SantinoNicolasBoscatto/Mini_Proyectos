using Microsoft.AspNetCore.Identity;

namespace MinimalAPIpeliculas.Repositorio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IHttpContextAccessor accessor;
        private readonly UserManager<IdentityUser> userManager;

        public UsuarioService(IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            this.accessor = accessor;
            this.userManager = userManager;
        }

        public async Task<IdentityUser?> ObtenerUsuario()
        {
            var emailClaim = accessor.HttpContext!.User.Claims.Where(x => x.Type == "email").FirstOrDefault();
            if (emailClaim == null) return null;

            var email = emailClaim.Value;
            return await userManager.FindByEmailAsync(email);
        }
    }
}
