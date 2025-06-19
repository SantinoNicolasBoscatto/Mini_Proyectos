using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        public StreamerDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Independientemente del Orden, ambas configuraciones son iguales
            //modelBuilder.Entity<Streamer>().HasMany(x => x.ListaVideos).WithOne(x => x.Streamer).HasForeignKey(x => x.StreamerId);
            modelBuilder.Entity<Video>().HasOne(x => x.Streamer).WithMany(x => x.ListaVideos).HasForeignKey(x => x.StreamerId);

            modelBuilder.Entity<VideoActor>()
            .HasKey(va => new { va.ActorId, va.VideoId });
            modelBuilder.Entity<VideoActor>().HasOne(va => va.Actor).WithMany(a => a.ListVideo).HasForeignKey(va => va.ActorId);
            modelBuilder.Entity<VideoActor>().HasOne(va => va.Video).WithMany(v => v.ListActores).HasForeignKey(va => va.VideoId);
        }

        // Al sobrescribir SaveChangesAsync() puedo setear globalmente los valores de BaseDomainModel de mis entidades
        // De esta forma puedo definir acciones que se ejecuten al guardar los cambios
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "system";
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Actor>? Actores { get; set; }
        public DbSet<Director>? Directores { get; set; }
        public DbSet<VideoActor>? VideosActores { get; set; }
    }
}
