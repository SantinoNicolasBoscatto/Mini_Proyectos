namespace WebApiActores.DTOs
{
    public class ColeccionDeRecursos<T> : RecursoDTO where T : class
    {
        public List<T> Valores { get; set; }
    }
}
