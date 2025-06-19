using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ManejoDePresupuestos.Models
{
    public class CuentaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre debe ser completado")]
        [StringLength(maximumLength: 50)]
        public string CuentaNombre { get; set; }
        [Display(Name = "Tipo Cuenta")]
        public int TipoCuentaId { get; set; } 
        public decimal Balance { get; set; }
        [StringLength(maximumLength: 1000)]
        public string Descripcion { get; set; }
        public string TipoCuenta { get; set; }
    }

    public class CuentaViewModel: CuentaDTO
    {
        public IEnumerable<SelectListItem> TiposCuentas { get; set; }

        public string urlRetorno { get; set; }

        public DateTime Tiempo { get; set; }

    }
}
