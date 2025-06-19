using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entitys
{
    public class Cine
    {
        public int CineId { get; set; }
        public string NombreCine { get; set; }
        public Point MyProperty { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalasDeCineHash { get; set; }
    }
}
