using Education.Application.Cursos;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EducationDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(GetCursoQuery.GetCursoQueryHandler));
builder.Services.AddCors(x => x.AddPolicy("corsApp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

app.UseCors("corsApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
