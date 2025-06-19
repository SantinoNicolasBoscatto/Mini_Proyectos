using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace ManejoDePresupuestos.Models
{
    public interface IConexionBD
    {
        Task Actualizar(TipoCuentaDTO tipoCuentaDTO);
        Task ActualizarCuenta(CuentaViewModel model);
        Task Borrar(int id);
        Task CrearTipoCuenta(TipoCuentaDTO tipoCuentaDTO);
        Task<bool> Existe(string nombre, int usuarioId);
        Task<IEnumerable<TipoCuentaDTO>> ListadoCuentas(int usuarioId);
        Task<TipoCuentaDTO> ObtenerId(int id, int usuarioId);
        Task OrdenarGrilla(IEnumerable<TipoCuentaDTO> tipoCuentaDTOs);
    }

    public class TipoCuentaRepositorio : IConexionBD
    {
        private string CadenaConexion { get; }
        public TipoCuentaRepositorio(IConfiguration configuration)
        {
            CadenaConexion = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearTipoCuenta(TipoCuentaDTO tipoCuentaDTO)
        {
            using var conexion = new SqlConnection(CadenaConexion);
            var id = await conexion.QuerySingleAsync<int>(@"Insert into TiposCuentas (UsuarioId,NombreCuenta,Orden) " +
                                             "OutPut inserted.Id values (@UsuarioId,@NombreCuenta,(select ISNULL(MAX(Orden+1), 1) from TiposCuentas))",
                                             tipoCuentaDTO);
            tipoCuentaDTO.Id = id;
        }

        public async Task<bool> Existe(string nombre, int usuarioId)
        {
            using var conexion = new SqlConnection(CadenaConexion);
            var aux = await conexion.QueryFirstOrDefaultAsync<int>(@"Select 1 from TiposCuentas where 
                                                                       NombreCuenta = @nombre and UsuarioId = @usuarioId",
                                                                       new {nombre, usuarioId});
            if (aux == 1)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<TipoCuentaDTO>> ListadoCuentas(int usuarioId)
        {
            using var conexion = new SqlConnection(CadenaConexion);
            return await conexion.QueryAsync<TipoCuentaDTO>(@"Select Id, NombreCuenta, usuarioId, Orden 
                                                                    from TiposCuentas where  usuarioId = @usuarioId order by Orden", 
                                                                    new {usuarioId});
        }

        public async Task Actualizar(TipoCuentaDTO tipoCuentaDTO)
        {
            using var conexion = new SqlConnection(CadenaConexion);
            await conexion.ExecuteAsync(@"Update TiposCuentas set NombreCuenta = @NombreCuenta where Id = @Id",tipoCuentaDTO);
        }

        public async Task<TipoCuentaDTO> ObtenerId(int id, int usuarioId)
        {
            using var conexion = new SqlConnection(CadenaConexion);
            var aux = await conexion.QueryFirstOrDefaultAsync<TipoCuentaDTO>(@"Select Id, NombreCuenta, Orden, UsuarioId from TiposCuentas where 
                                                                    UsuarioId = @UsuarioId and Id = @Id", new {id, usuarioId});
            return aux;
        }

        public async Task Borrar(int id)
        {
            using var conexion = new SqlConnection(CadenaConexion);
            await conexion.ExecuteAsync("Delete from TiposCuentas where Id = @id", new {id});
        }

        public async Task OrdenarGrilla(IEnumerable<TipoCuentaDTO> tipoCuentaDTOs)
        {
            var query = "UPDATE TiposCuentas set Orden = @Orden where Id = @Id;";
            using var conexion = new SqlConnection(CadenaConexion);
            await conexion.ExecuteAsync(query, tipoCuentaDTOs);
        }

        [HttpPost]
        public async Task ActualizarCuenta(CuentaViewModel model)
        {
           using var conexion = new SqlConnection(CadenaConexion);
            await conexion.ExecuteAsync(@"Update Cuentas set Nombre = @CuentaNombre, TipoCuentaId = @TipoCuentaId,Balance = @Balance, 
                                        Descripcion = @Descripcion where Id = @Id", model);
        }

    }


}
