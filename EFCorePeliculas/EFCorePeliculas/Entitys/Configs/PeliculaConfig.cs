using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entitys.Configs
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(prop => prop.Titulo).HasMaxLength(50).IsRequired();
            builder.Property(prop => prop.FechaEstreno).HasColumnType("date");
            builder.Property(prop => prop.PosterURL).IsUnicode(false);

            builder.HasMany(p => p.GenerosHash).WithMany(g => g.PeliculasHash).UsingEntity(j => j.ToTable("GEnerosPelucas"));
        }
    }
}
