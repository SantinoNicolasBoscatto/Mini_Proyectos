using Pacagroup.Trade.Services.gRPC.Services;
using Pacagroup.Trade.Persistence;
using Pacagroup.Trade.Application;
using Pacagroup.Trade.Services.gRPC;
using Pacagroup.Trade.Services.gRPC.Commons.GlobalExceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(opt =>
{
    opt.Interceptors.Add<GlobalExceptionHandler>();
});
builder.Services.AddGrpcReflection();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddPresentationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OrderService>();
app.MapGrpcReflectionService();

app.Run();
