using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinimalAPIpeliculas;
using MinimalAPIpeliculas.Endpoints;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Repositorio;
using MinimalAPIpeliculas.Servicios;
using MinimalAPIpeliculas.Swagger;
using MinimalAPIpeliculas.Utilidades;

var builder = WebApplication.CreateBuilder(args);
var origenesPermitidos = builder.Configuration.GetValue<string>("Origenes")!;

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });

    options.AddPolicy("libre",config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
//builder.Services.AddOutputCache();

builder.Services.AddStackExchangeRedisOutputCache(opt =>
{
    opt.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddEndpointsApiExplorer(); // Permitira a Swagger explorar los Endpoints que tenemos y listarlos
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Peliculas API",   
        Description = "",
        Contact = new OpenApiContact { Email = "", Name = ""},
        Version = "v1"
    });


    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    opt.OperationFilter<FiltroSwagger>();

    //opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        }, new string[]{}
    //    }
    //});
});
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<IActoresService, ActoresService>();
builder.Services.AddScoped<IFilesService, FileServiceLocal>();
builder.Services.AddScoped<IPeliculasService, PeliculasService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IErroresService, ErroresService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddAuthentication().AddJwtBearer(opt => {
    opt.MapInboundClaims = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = Llaves.ObtenerLlave(builder.Configuration).SingleOrDefault(), //Este metodo si solo quiero usar las llaves que mi app emitio
        /*IssuerSigningKeys = Llaves.ObtenerTodasLasLlaves(builder.Configuration)*/ // Este metodo es para si quiero trabajar con mas de una llave
                                                                                    // de validacion, por ejemplo si mis JWT validan con mi APP, pero
                                                                                    // tambien con gmail, facebook, hotmail, etc.
    };
}); 


builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("esAdmin", policy => policy.RequireClaim("esadmin"));
});




builder.Services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<UserManager<IdentityUser>>();
builder.Services.AddScoped<SignInManager<IdentityUser>>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseCors();
app.UseOutputCache();
app.UseAuthorization();

app.MapGet("/", [EnableCors(policyName: "libre")]() => "Hola Papu");

app.MapPost("/modelbinding", (string? nombre) =>
{
    if (nombre == null) nombre = "Vacio";
    return TypedResults.Ok(nombre);
});

app.MapGroup("/generos").MapGeneros();
app.MapGroup("/actores").MapActores();
app.MapGroup("/peliculas").MapPeliculas();
app.MapGroup("/pelicula/{peliculaId:int}/comentarios").MapComentarios();
app.MapGroup("/usuarios").MapUsuarios();





app.Run();



