using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entitys
{
    public class Mensaje
    {
        public int id { get; set; }
        public string mensaje { get; set; }
        public int EmisorId { get; set; }
        public Persona Emisor { get; set; }
        public int ReceptorId { get; set; }
        public Persona Receptor { get; set; }
    }

    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [InverseProperty("Emisor")]
        public List<Mensaje> MensajesEnviados { get; set; }
        [InverseProperty("Receptor")]
        public List<Mensaje> MensajesRecibidos { get; set; }
    }
}
