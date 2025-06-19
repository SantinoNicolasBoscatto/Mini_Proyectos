using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entitys.Configs
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.Property(x => x.NombreCine).HasMaxLength(150).IsRequired();
            builder.HasOne(x => x.CineOferta).WithOne(x => x.Cine).HasForeignKey<CineOferta>(co => co.CineId);
        }
    }
}
