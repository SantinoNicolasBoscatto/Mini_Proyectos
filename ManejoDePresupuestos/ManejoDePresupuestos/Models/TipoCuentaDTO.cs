using ManejoDePresupuestos.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoDePresupuestos.Models
{
    public class TipoCuentaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Porfavor Complete el Campo Nombre")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Error el Nombre de la Cuenta debe Contener " +
            "entre {2} a {1} Caracteres")]
        [PrimeraLetraMayuscula]
        [Remote(action: "ValidarNombre", controller: "TiposCuentas")]
        public string NombreCuenta { get; set;}
        public int UsuarioId { get; set; }
        public int Orden { get; set; }
    }
}
