using Clean_Architecture.Adapters;
using Clean_Architecture.Adapters.Dtos;
using Clean_Architecture.API.Middlewares;
using Clean_Architecture.API.Validators;
using Clean_Architecture.Application;
using Clean_Architecture.Domain;
using Clean_Architecture.Infrastructure;
using Clean_Architecture.Mappers;
using Clean_Architecture.Mappers.DTOs.Request;
using Clean_Architecture.Models;
using Clean_Architecture.Presenters;
using Clean_Architecture.Repository;
using ExternalService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectar los validadores
builder.Services.AddValidatorsFromAssemblyContaining<BeerValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IRepository<Beer>, Repository>();
builder.Services.AddScoped<IRepositorySearch<SaleModel, Sale>, SaleRepository>();
builder.Services.AddScoped<IPresenter<Beer, BeerViewModel>, BeerPresenter>();
builder.Services.AddScoped<IPresenter<Beer, BeerDetailViewModel>, BeerDetailPresenter>();
builder.Services.AddScoped<IMapper<BeerResquestDTO, Beer>, BeerMapper>();


builder.Services.AddScoped<IExternalServiceAdapter<Post>, PostExternalServiceAdapters>();
builder.Services.AddScoped<IExternalService<PostServiceDTO>, PostService>();
builder.Services.AddScoped<GetPostUseCase>();
builder.Services.AddScoped<GetSalesSearchUseCases<SaleModel>>();

builder.Services.AddHttpClient<IExternalService<PostServiceDTO>, PostService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["BaseUrl"]!);
});


builder.Services.AddScoped<GetBeerUseCase<Beer, BeerViewModel>>();
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerDetailViewModel>>();
builder.Services.AddScoped<AddBeerUseCase<BeerResquestDTO>>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();


app.MapGet("/beer", async (GetBeerUseCase<Beer, BeerViewModel> useCase) =>
{
   return await useCase.ExecuteAsync();
}).WithName("GetBeer").WithOpenApi();


app.MapGet("/beerdetail", async (GetBeerUseCase<Beer, BeerDetailViewModel> useCase) =>
{
    return await useCase.ExecuteAsync();
}).WithName("GetBeerDetail").WithOpenApi();


app.MapPost("/beer", async (AddBeerUseCase<BeerResquestDTO> useCase, BeerResquestDTO dto, IValidator<BeerResquestDTO> validator) =>
{
    var result = await validator.ValidateAsync(dto);
    if (!result.IsValid) return Results.ValidationProblem(result.ToDictionary());

    await useCase.ExecuteAsync(dto);
    return Results.Created();
}).WithName("AddBeer").WithOpenApi();


app.MapGet("/posts", async (GetPostUseCase postUseCase) =>
{
    return await postUseCase.ExecuteAsync();
});


app.MapGet("/salessearch/{total}", async (GetSalesSearchUseCases<SaleModel> useCase, int total) =>
{
    return await useCase.ExecuteAsync(s => s.Total > total);
}).WithName("Filtrado").WithOpenApi();

app.Run();

