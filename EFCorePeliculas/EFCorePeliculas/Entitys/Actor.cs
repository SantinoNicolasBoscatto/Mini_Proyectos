using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entitys
{
    public class Actor
    {
        [Key]
        public int IdActor { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime? Born { get; set; }
        public HashSet<PeliculaActor> PeliculaActorHash { get; set; }
    }
}
