using Portafolio.Repositorios;

namespace Portafolio.Models
{

    public class Persona:IRepositorioProyectos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public List<ProyectoDTO> Obtener()
        {
            throw new NotImplementedException();
        }
    }
}
