using Dapper;
using ManejoDePresupuestos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoDePresupuestos.Controllers
{
    public class TiposCuentasController : Controller
    {
        public IConexionBD ConexionBD { get; }
        public IUsuarioID UsuarioID { get; }
        // Inyecto Dependencias
        public TiposCuentasController(IConexionBD conexionBD, IUsuarioID usuarioID) 
        {
            ConexionBD = conexionBD;
            UsuarioID = usuarioID;
        }

        // Traigo el usuario ID y las cuentas asociadas a el
        public async Task<IActionResult> Index()
        {
            int usuarioId = await UsuarioID.DevolverUsuarioId();
            var tiposCuentas = await ConexionBD.ListadoCuentas(usuarioId);
            return View(tiposCuentas); 
        }

        // Me lleva al modelo de Crear
        public IActionResult Crear()
        {
            return View();            
        }

        // Primero Valido si estan OK mis validaciones, si no es asi devuelvo el objeto a los campos con el ASP-FOr enlazando y
        //Manteniendo valores. Tomo el Id del usuario, pregunto si existe una cuenta una misma cuenta del mismo usuario, si es 
        // asi creo un error y devuelvo al form con el objeto DTO. Sino creo la cuenta y voy a index
        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuentaDTO tipoCuentaDTO) 
        {
            if (!ModelState.IsValid)
                return View(tipoCuentaDTO);
            tipoCuentaDTO.UsuarioId = await UsuarioID.DevolverUsuarioId();
            if (await ConexionBD.Existe(tipoCuentaDTO.NombreCuenta, tipoCuentaDTO.UsuarioId))
            {
                ModelState.AddModelError(nameof(tipoCuentaDTO.NombreCuenta), "El nombre de la cuenta ya existe");
                return View(tipoCuentaDTO);
            }
            await ConexionBD.CrearTipoCuenta(tipoCuentaDTO);
            return RedirectToAction("Index");

        }

        // Tomo el valor del usuario y verifico si existe esa cuenta en ese ID, si es verdad voy a editar pasando el objeto 
        // DTO para editar.
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            var tipoCuenta = await ConexionBD.ObtenerId(id, usuarioId);

            if (tipoCuenta == null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(tipoCuenta);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(TipoCuentaDTO tipoCuentaDTO)
        {
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            var tipoCuentaExiste = await ConexionBD.ObtenerId(tipoCuentaDTO.Id, usuarioId);
            if (tipoCuentaExiste is null)
            {
                return RedirectToAction("No Encontrado", "Home");
            }
            await ConexionBD.Actualizar(tipoCuentaDTO);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            var tipoCuentaExiste = await ConexionBD.ObtenerId(id, usuarioId);
            if (tipoCuentaExiste is null)
            {
                return RedirectToAction("No Encontrado", "Home");
            }
            await ConexionBD.Borrar(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> ValidarNombre(TipoCuentaDTO tipoCuentaDTO)
        {
            tipoCuentaDTO.UsuarioId = await UsuarioID.DevolverUsuarioId();
            var aux = await ConexionBD.Existe(tipoCuentaDTO.NombreCuenta, tipoCuentaDTO.UsuarioId);
            if (aux)
            {
                return Json("Error, este nombre ya existe");
            }
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> OrdenarGrilla([FromBody] int[] ids)
        {
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            var tiposCuentas = await ConexionBD.ListadoCuentas(usuarioId);
            var Myids = tiposCuentas.Select(x => x.Id);
            var except = ids.Except(Myids).ToList();
            if (except.Count > 0)
            {
                return Forbid();
            }
            var tiposCuentasOrdenados = ids.Select((valor, indice) => new TipoCuentaDTO { Id = valor, Orden = indice + 1 }).AsEnumerable();
            await ConexionBD.OrdenarGrilla(tiposCuentasOrdenados);
            return Ok();
        }
        
    }
}
