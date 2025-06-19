using Education.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext() { }

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de Testing",
                    Titulo = "Testing Master",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddDays(1),
                    Precio = 33
                },
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de Java",
                    Titulo = "Java Master",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddDays(1),
                    Precio = 60
                }
            );
            modelBuilder.Entity<Curso>().Property(x => x.Precio).HasPrecision(14,2);
        }

        public DbSet<Curso> Cursos { get; set; } = null!;
    }
}
