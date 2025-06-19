namespace WebApiActores.DTOs
{
    public class DatoHATEOAS
    {
        public DatoHATEOAS(string enpoint, string desc, string metodo)
        {
            this.Descripcion = desc;
            this.Metodo = metodo;
            this.Endpoint = enpoint;
        }

        public string Endpoint { get; private set; }
        public string Descripcion { get; private set; }
        public string Metodo { get; private set; }
    }
}
