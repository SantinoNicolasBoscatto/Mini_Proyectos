using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entitys
{
    //[Table("TablaGenero")]
    public class Genero
    {
        public int Identificador { get; set; }
        public string Name { get; set; }
        public HashSet<Pelicula> PeliculasHash { get; set; }
    }
}
