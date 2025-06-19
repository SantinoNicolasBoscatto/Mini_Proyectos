using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entitys
{
    public class SalaDeCine
    {
        [Key]
        public int SalaId { get; set; }
        public TipoSala TipoSala { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }
        public Cine Cine { get; set; }
        public HashSet<Pelicula> PeliculaHash { get; set; }
    }

}
