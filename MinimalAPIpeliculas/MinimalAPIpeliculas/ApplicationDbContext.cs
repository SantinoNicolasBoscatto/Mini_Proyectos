using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinimalAPIpeliculas.Entitys;
using MinimalAPIpeliculas.Repositorio;

namespace MinimalAPIpeliculas
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<GeneroPelicula> GenerosPeliculas { get; set; }
        public DbSet<ActoresPeliculas> ActoresPeliculas { get; set; }
        public DbSet<Error> Errores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>().Property(x => x.Nombre).HasMaxLength(75);
            modelBuilder.Entity<Actor>().Property(x => x.Nombre).HasMaxLength(75);
            modelBuilder.Entity<Actor>().Property(x => x.Foto).IsUnicode();

            modelBuilder.Entity<Pelicula>().Property(x => x.Titulo).HasMaxLength(150);
            modelBuilder.Entity<Pelicula>().Property(x => x.Poster).IsUnicode();

            modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.PeliculaId, x.GeneroId });
            modelBuilder.Ignore<PeliculasService>();
            modelBuilder.Entity<ActoresPeliculas>().HasKey(x => new { x.PeliculaId, x.ActorId });

            modelBuilder.Entity<IdentityUser>().ToTable("Usuarios");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolesClaims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuariosClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuariosLogins");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuariosRoles");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuariosTokens");
        }
    }
}
