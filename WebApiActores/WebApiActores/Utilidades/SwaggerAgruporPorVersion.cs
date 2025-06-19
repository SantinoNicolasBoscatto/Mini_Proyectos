using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebApiActores.Utilidades
{
    public class SwaggerAgruporPorVersion : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var nameSpaceController = controller.ControllerType.Namespace; // Controllers.V1
            var versionAPI = nameSpaceController.Split(".").Last().ToLower(); // v1
            controller.ApiExplorer.GroupName = versionAPI;
        }
    }
}
