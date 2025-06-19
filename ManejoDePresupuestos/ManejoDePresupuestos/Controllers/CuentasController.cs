using AutoMapper;
using ManejoDePresupuestos.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoDePresupuestos.Controllers
{
    public class CuentasController : Controller
    {
        private readonly IMapper mapper;
        private readonly IConexionBD conexionBD;

        public CuentasController(IUsuarioID usuarioID, ICuentaRepo cuentaRepo, IMapper mapper, IConexionBD conexionBD) 
        {
            UsuarioID = usuarioID;
            CuentaRepo = cuentaRepo;
            this.mapper = mapper;
            this.conexionBD = conexionBD;
        }

        public IUsuarioID UsuarioID { get; }
        public ICuentaRepo CuentaRepo { get; }

        public async Task<IActionResult> Crear()
        {
            var modelo = new CuentaViewModel();
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            var tiposCuentas = await conexionBD.ListadoCuentas(usuarioId);
            modelo.TiposCuentas = tiposCuentas.Select(x => new SelectListItem(x.NombreCuenta, x.Id.ToString()));
            modelo.Tiempo = DateTime.Parse(DateTime.Now.ToString("g"));
            return View(modelo);
        }
        [HttpPost]
        public async Task<IActionResult> Crear(CuentaViewModel cuentaViewModel, string urlRetorno)
        {
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            //var TiposCuentas = await ConexionBD.ObtenerId(cuentaViewModel.Id,usuarioId);
            //if (TiposCuentas is null)
            //{
            //    return RedirectToAction("NoEncontrado", "Home");
            //}
            if (!ModelState.IsValid)
            {
                var modelo = new CuentaViewModel();
                var Listado = await conexionBD.ListadoCuentas(usuarioId);
                modelo.TiposCuentas = Listado.Select(x => new SelectListItem(x.NombreCuenta, x.Id.ToString()));
                return View(modelo);
            }
            await CuentaRepo.AgregarCuenta(cuentaViewModel);
            return Redirect(TempData["UrlActual"] as string);
        }

        public async Task<IActionResult> Index()
        {
            TempData["UrlActual"] = HttpContext.Request.GetDisplayUrl();
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            var cuentas = await CuentaRepo.Listado(usuarioId);
            var modelo = cuentas.GroupBy(x => x.TipoCuenta).Select(grupo => new IndiceCuentasViewModel
            {
                TipoCuenta = grupo.Key,
                Cuentas = grupo.AsEnumerable()
            }).ToList();
            return View(modelo);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            var Cuenta = await CuentaRepo.ObtenerPorId(id, usuarioId);

            if (Cuenta is null)
            {
                return View("NoEncontrado", "Home");
            }

            var modelo = mapper.Map<CuentaViewModel>(Cuenta);
            modelo.TiposCuentas = await ObtenerTiposCuentas(usuarioId);
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CuentaViewModel cuentaView)
        {
            var usuarioId = await UsuarioID.DevolverUsuarioId();
            var cuenta = await conexionBD.ObtenerId(cuentaView.TipoCuentaId, usuarioId);
            if (cuenta is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            var tipoCuenta = await conexionBD.ObtenerId(cuentaView.TipoCuentaId, usuarioId);

            if (tipoCuenta is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await conexionBD.ActualizarCuenta(cuentaView);
            return RedirectToAction("Index");

        }

        private  async Task<IEnumerable<SelectListItem>> ObtenerTiposCuentas (int usuarioId)
        {
            var tiposCuentas = await conexionBD.ListadoCuentas(usuarioId);
            var aux  = tiposCuentas.Select(x => new SelectListItem  (x.NombreCuenta, x.Id.ToString()));
            return aux;
        }
    }
}
