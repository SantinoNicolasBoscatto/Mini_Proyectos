using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PeliculasAPI.DTOs;
using PeliculasAPI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly HashService hashService;
        private readonly IDataProtector dataProtector;

        public CuentasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IConfiguration configuration, IDataProtectionProvider dataProtection, HashService hashService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.hashService = hashService;
            dataProtector = dataProtection.CreateProtector("string_de_proposito");
        }


        [HttpGet("hash/{textoplano}")]
        public ActionResult Hashear(string textoplano)
        {
            var result = hashService.Hash(textoplano);
            return Ok(result);
        }

        [HttpGet("Encriptar")]
        public ActionResult Encriptar(string textPlain)
        {
            var cifrado = dataProtector.Protect(textPlain);
            var desencriptado = dataProtector.Unprotect(cifrado);
            return Ok(new
            {
                cifrado,
                plano = desencriptado
            });
        }

        [HttpGet("EncriptarPorTiempo")]
        public ActionResult EncriptarPorTiempo(string textPlain)
        {
            var tiempoProtector = dataProtector.ToTimeLimitedDataProtector();
            var cifrado = tiempoProtector.Protect(textPlain, TimeSpan.FromSeconds(10));
            var desencriptado = tiempoProtector.Unprotect(cifrado);
            return Ok(new
            {
                cifrado,
                plano = desencriptado
            });
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<RespuestaAutenticacionDTO>> Registrar(CredencialesUsuarioDTO cred)
        {
            var user = new IdentityUser { UserName = cred.Email, PasswordHash = cred.Password };
            var result = await userManager.CreateAsync(user, cred.Password);
            if (!result.Succeeded) return BadRequest(result);

            return await ConstruirToken(cred);
        }

        [HttpPost("login")]
        public async Task<ActionResult<RespuestaAutenticacionDTO>> Login(CredencialesUsuarioDTO cred)
        {
            var result = await signInManager.PasswordSignInAsync(cred.Email, cred.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded) return BadRequest();
            return await ConstruirToken(cred);
        }

        [HttpGet("RenovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RespuestaAutenticacionDTO>> Renovar()
        {
            var claim = HttpContext.User.Claims.Where(x => x.Type == "email").FirstOrDefault();
            var email = claim!.Value;
            var credenciales = new CredencialesUsuarioDTO
            {
                Email = email
            };
            return await ConstruirToken(credenciales);
        }


        private async Task<RespuestaAutenticacionDTO> ConstruirToken(CredencialesUsuarioDTO cred)
        {
            // Estos pueden ser accesibles por el usuario, por ende no se debe poner data sensible en el.
            var claims = new List<Claim>()
            {
                new Claim("email", cred.Email)
            };

            var usuario = await userManager.FindByNameAsync(cred.Email);
            var claimsBD = await userManager.GetClaimsAsync(usuario!);
            claims.AddRange(claimsBD);

            // Aca extraemos la llave secreta para firmar el Token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.UtcNow.AddHours(5);
            var token = new JwtSecurityToken(issuer: null, audience: null, expires: exp, claims: claims, signingCredentials: creds);

            return new RespuestaAutenticacionDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Exp = exp
            };
        }


        [HttpPost("hacerAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> HacerAdmin(AdminDTO adminDTO)
        {
            var usuario = await userManager.FindByNameAsync(adminDTO.Email);
            await userManager.AddClaimAsync(usuario!, new Claim("EsAdmin", "1"));
            return NoContent();
        }

        [HttpPost("removerAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> RemoverAdmin(AdminDTO adminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(adminDTO.Email);
            await userManager.RemoveClaimAsync(usuario!, new Claim("EsAdmin", "1"));
            return NoContent();
        }
    }
}
