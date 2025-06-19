using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MinimalAPIpeliculas.DTO;
using MinimalAPIpeliculas.Filtros;
using MinimalAPIpeliculas.Repositorio;
using MinimalAPIpeliculas.Utilidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MinimalAPIpeliculas.Endpoints
{
    public static class EndpointUsuarios
    {
        public static RouteGroupBuilder MapUsuarios(this RouteGroupBuilder group) 
        {
            group.MapPost("/registrar", RegistrarUsuarios).AddEndpointFilter<FiltroValidaciones<CrendencialesUsuariosDTO>>();
            group.MapPost("/login", Login).AddEndpointFilter<FiltroValidaciones<CrendencialesUsuariosDTO>>();
            group.MapPost("/haceradmin", HacerAdmin)
                .AddEndpointFilter<FiltroValidaciones<EditarClaimDTO>>().RequireAuthorization("esadmin");
            group.MapPost("/removeradmin", HacerAdmin)
                .AddEndpointFilter<FiltroValidaciones<EditarClaimDTO>>().RequireAuthorization("esadmin");
            group.MapGet("/renovarToken", RenovarToken).RequireAuthorization();
            return group;
        }

        static async Task<Results<Ok<RespuestaAutenticacionDTO>, BadRequest<string>>> Login
            (CrendencialesUsuariosDTO crendencialesDTO, [FromServices] SignInManager<IdentityUser> signManager,
            [FromServices] UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            var usuario = await userManager.FindByEmailAsync(crendencialesDTO.Email);
            if (usuario == null) return TypedResults.BadRequest("Login Incorrecto");

            var resultado = await signManager.CheckPasswordSignInAsync(usuario, crendencialesDTO.Password, lockoutOnFailure: false);
            if(resultado.Succeeded)
            {
                var respuestaAutenticacion = await ConstruirToken(crendencialesDTO,configuration, userManager);
                return TypedResults.Ok(respuestaAutenticacion);
            }

            return TypedResults.BadRequest("Login Incorrecto");
        }


        static async Task<Results<Ok<RespuestaAutenticacionDTO>, BadRequest<IEnumerable<IdentityError>>>> RegistrarUsuarios
            (CrendencialesUsuariosDTO crendencialesDTO, [FromServices] UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            var usuario = new IdentityUser
            {
                UserName = crendencialesDTO.Email,
                Email = crendencialesDTO.Email
            };
            var resultado = await userManager.CreateAsync(usuario, crendencialesDTO.Password);

            if (resultado.Succeeded)
            {
                var respuestaAutenticacion = await ConstruirToken(crendencialesDTO, configuration, userManager);
                return TypedResults.Ok(respuestaAutenticacion);
            }

            return TypedResults.BadRequest(resultado.Errors);
        }

        
        private async static Task<RespuestaAutenticacionDTO> ConstruirToken(CrendencialesUsuariosDTO crendencialesDTO, IConfiguration configuration,
            UserManager<IdentityUser> userManager)
        {
            // Definire que claims quiero que tenga mi usuario, en este no debo poner informacion secrete porque puede ser leida.
            var claims = new List<Claim>
            {
                new Claim("email", crendencialesDTO.Email),
                new Claim("usuario", crendencialesDTO.Email),
            };

            // Obtengo el Usuario, sus Claims de la BD y le anexo los claims de la BD del usuario a los claims con los que construiere
            //El Token
            var usuario = await userManager.FindByNameAsync(crendencialesDTO.Email);
            var claimsDB = await userManager.GetClaimsAsync(usuario!);
            claims.AddRange(claimsDB);

            // Obtengo mi Llave
            var llave = Llaves.ObtenerLlave(configuration);
            //Creo la firma
            var credenciales = new SigningCredentials(llave.First(), SecurityAlgorithms.HmacSha256);
            // Creo la fecha de Expiracion
            var expiracion = DateTime.UtcNow.AddYears(1);

            //Creo el token
            var tokenDeSeguridad = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, 
                signingCredentials: credenciales);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenDeSeguridad);

            return new RespuestaAutenticacionDTO
            {
                Token = token,
                Expiracion = expiracion,
            };
        }


        static async Task<Results<NoContent, NotFound>> HacerAdmin(EditarClaimDTO editarClaimDTO, 
            [FromServices] UserManager<IdentityUser> userManager)
        {
            var usuario = await userManager.FindByEmailAsync(editarClaimDTO.Email);
            if (usuario == null) return TypedResults.NotFound();

            await userManager.AddClaimAsync(usuario, new Claim("esadmin", "true"));
            return TypedResults.NoContent();
        }

        static async Task<Results<NoContent, NotFound>> RemoverAdmin(EditarClaimDTO editarClaimDTO,
            [FromServices] UserManager<IdentityUser> userManager)
        {
            var usuario = await userManager.FindByEmailAsync(editarClaimDTO.Email);
            if (usuario == null) return TypedResults.NotFound();

            await userManager.RemoveClaimAsync(usuario, new Claim("esadmin", "true"));
            return TypedResults.NoContent();
        }



        public async static Task<Results<Ok<RespuestaAutenticacionDTO>, NotFound>> RenovarToken(IUsuarioService usuarioService,
            IConfiguration configuration, [FromServices] UserManager<IdentityUser> userManager)
        {
            var usuario = await usuarioService.ObtenerUsuario();
            if(usuario == null) return TypedResults.NotFound();

            var credencialesUsuarioDTO = new CrendencialesUsuariosDTO { Email = usuario.Email!};
            var respuestaAutenticacionDTO = await ConstruirToken(credencialesUsuarioDTO, configuration, userManager);
            return TypedResults.Ok(respuestaAutenticacionDTO);
        }
    }
}
