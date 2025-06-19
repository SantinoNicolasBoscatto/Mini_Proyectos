using Education.Domain.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.DTO
{
    public class CursoDTO
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime? FechaPublicacion { get; set; }
        public Decimal Precio { get; set; }
    }
}
