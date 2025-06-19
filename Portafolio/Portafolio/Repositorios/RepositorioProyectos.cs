using Portafolio.Models;

namespace Portafolio.Repositorios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> Obtener();
    }

    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoDTO> Obtener()
        {

            return new List<ProyectoDTO>
            {
                new ProyectoDTO
                {
                    Titulo = "App De Gestion de Articulos",
                    Desc = "Aplicación Winforms que permite gestionar artículos de forma eficiente. Puedes cargar, modificar, eliminar y leer información sobre ellos de manera sencilla y rápida atraves de un DataGridView, pudiendo gestionar el inventario de forma practica.",
                    Img = "/Images/P1.png",
                    Link = "https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P3_Inventario%20de%20Productos"
                },

                new ProyectoDTO
                {
                    Titulo = "App Simulador De Gran Turismo",
                    Link = "https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P4_Touge-App",
                    Img = "/Images/P2.png",
                    Desc = "Aplicación Winforms combina la simulación de un modo de vida con la jugabilidad de Gran Turismo. Ofrece un completo CRUD para diversos objetos, como automóviles, insumos y mejoras. Implementa un sistema de días que avanzan según las acciones del usuario, con validaciones para actividades como alquileres, comida y facturas. Además, incluye una mecánica de desgaste del automóvil basada en las carreras, con la posibilidad de comprar insumos y mejoras para optimizar su rendimiento."
                },

                new ProyectoDTO
                {
                     Titulo = "App Web Con Webforms De Gestion de Articulos",
                    Link = "https://github.com/SantinoNicolasBoscatto/Proyectos-Finales/tree/main/P5_AppWeb-Articulos/TPFinalNivel3BoscattoSantino",
                    Img = "/Images/P3.png",
                    Desc = "Aplicación web, desarrollada con Webforms, permite gestionar artículos con un completo CRUD. Incluye funciones de inicio de sesión, validaciones de datos y un sistema de favoritos. Los usuarios pueden modificar sus perfiles y registrarse fácilmente. Con una interfaz intuitiva y funcionalidades robustas, ofrece una experiencia completa para la gestión de contenido y perfiles en línea."
                }
            };

        }
    }
}
