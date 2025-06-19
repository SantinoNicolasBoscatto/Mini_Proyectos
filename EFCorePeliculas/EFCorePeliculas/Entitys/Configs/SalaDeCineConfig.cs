using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entitys.Configs
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(x => x.Precio).HasPrecision(precision: 9, scale: 2);
            builder.Property(x => x.TipoSala).HasDefaultValue(TipoSala.DosDimensiones);
        }
    }

}
