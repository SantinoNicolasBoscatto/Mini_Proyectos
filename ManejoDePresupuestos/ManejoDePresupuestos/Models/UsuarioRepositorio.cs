using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ManejoDePresupuestos.Models
{
    public interface IUsuarioID
    {
        Task<int> DevolverUsuarioId();
    }
    public class UsuarioRepositorio : IUsuarioID
    {
        public UsuarioRepositorio(IConfiguration configuration)
        {
            Cs = configuration.GetConnectionString("DefaultConnection");
        }

        public string Cs { get; }

        public async Task<int> DevolverUsuarioId()
        {
            using var conexion = new SqlConnection(Cs);
            var myid = await conexion.ExecuteScalarAsync<int>("Select Top 1 UsuarioId from Usuarios");
            return myid;
        }
    }
}
