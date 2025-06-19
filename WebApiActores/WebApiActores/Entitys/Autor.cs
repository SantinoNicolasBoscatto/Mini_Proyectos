using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiActores.Validaciones;

namespace WebApiActores.Entitys
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Autor Requiere un nombre")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre del autor no puede ser mayor a {1}")]
        public string Nombre { get; set; }
        public List<AutorLibro> ListaAutoresLibros { get; set; }

    }
}
