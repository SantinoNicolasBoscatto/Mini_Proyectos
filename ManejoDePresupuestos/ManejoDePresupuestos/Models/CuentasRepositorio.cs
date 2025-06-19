using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;

namespace ManejoDePresupuestos.Models
{
    public interface ICuentaRepo
    {
        Task AgregarCuenta(CuentaViewModel cuentas);
        Task<IEnumerable<CuentaViewModel>> Listado(int usuarioId);
        Task<CuentaViewModel> ObtenerPorId(int id, int usuarioId);
    }

    public class CuentasRepositorio : ICuentaRepo
    {
        public string Cs { get; set; }
        public CuentasRepositorio(IConfiguration configuration)
        {
            Cs = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AgregarCuenta(CuentaViewModel cuentas)
        {
            using var conexion = new SqlConnection(Cs);

            var Myid = await conexion.QuerySingleAsync<int>(@"insert into Cuentas (Nombre, TipoCuentaId, Balance, Descripcion) Output Inserted.Id
                                        values (@CuentaNombre, @TipoCuenta, @Balance, @Descripcion)", new
            {
                CuentaNombre = cuentas.CuentaNombre,
                TipoCuenta = cuentas.TipoCuentaId,
                Balance = cuentas.Balance,
                Descripcion = cuentas.Descripcion != null ? cuentas.Descripcion : (object)DBNull.Value
            });
        }

        public async Task<IEnumerable<CuentaViewModel>> Listado(int usuarioId)
        {
            using var conexion = new SqlConnection(Cs);
            return await conexion.QueryAsync<CuentaViewModel>(@"Select C.Id,  C.Nombre, C.Balance,  C.Descripcion, t.NombreCuenta as TipoCuenta 
                                                        from Cuentas C Inner JOIN TiposCuentas T ON T.Id = C.TipoCuentaId where T.UsuarioId =
                                                        @usuarioId order by T.Orden", new { usuarioId });

        }

        public async Task<CuentaViewModel> ObtenerPorId(int id, int usuarioId)
        {
            using var connection = new SqlConnection(Cs);
            var aux = await connection.QueryFirstOrDefaultAsync<CuentaViewModel>(@"Select C.Id as Id,  C.Nombre as CuentaNombre, C.Balance,  C.Descripcion as Descripcion, 
                                                                                 t.Id as TipoCuentaId 
                                                        from Cuentas C Inner JOIN TiposCuentas T ON T.Id = C.TipoCuentaId where T.UsuarioId =
                                                        @usuarioId and C.Id = @Id order by T.Orden", new { usuarioId, id});
            return aux;
        }

    }
}
