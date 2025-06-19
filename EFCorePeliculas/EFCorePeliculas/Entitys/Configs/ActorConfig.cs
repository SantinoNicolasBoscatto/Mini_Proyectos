using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entitys.Configs
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150)
           .IsRequired();
            builder.Property(x => x.Born)
           .IsRequired(false)
           .HasColumnType("date");
        }
    }
}
