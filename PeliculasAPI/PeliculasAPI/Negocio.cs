using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Entidades;

namespace PeliculasAPI
{
    public class Negocio : IdentityDbContext
    {
        public Negocio(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActoresPeliculas>().HasKey(x => new { x.PeliculaId, x.ActorId });
            modelBuilder.Entity<GenerosPeliculas>().HasKey(x => new { x.PeliculaId, x.GeneroId });
            modelBuilder.Entity<SalasPeliculas>().HasKey(x => new { x.PeliculaId, x.SalaDeCineId });
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<ActoresPeliculas> ActoresPeliculas { get; set; }
        public DbSet<GenerosPeliculas> GenerosPeliculas { get; set; }
        public DbSet<SalasDeCine> SalasDeCines { get; set; }
        public DbSet<SalasPeliculas> SalasPeliculas { get; set; }
    }
}
