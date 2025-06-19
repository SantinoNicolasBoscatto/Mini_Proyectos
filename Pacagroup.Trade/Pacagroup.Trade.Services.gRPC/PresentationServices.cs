using Pacagroup.Trade.Services.gRPC.Commons.GlobalExceptions;
using System.Reflection;

namespace Pacagroup.Trade.Services.gRPC
{
    public static class PresentationServices
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            //service.AddGrpc(opt =>
            //{
            //    opt.Interceptors.Add<GlobalExceptionHandler>();
            //});
            return service;
        }
    }
}
