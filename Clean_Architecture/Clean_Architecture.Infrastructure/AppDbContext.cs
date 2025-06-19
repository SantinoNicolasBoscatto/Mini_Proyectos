using Clean_Architecture.Models;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerModel>().ToTable("Beer");
            modelBuilder.Entity<SaleModel>().ToTable("Sale");
            modelBuilder.Entity<ConceptModel>().ToTable("Concept");

            modelBuilder.Entity<SaleModel>()
                .HasMany(x => x.Concepts)
                .WithOne()
                .HasForeignKey(x => x.IdSale)
                .OnDelete(DeleteBehavior.Cascade);
        }


        public DbSet<BeerModel> Beers { get; set; } = null!;
        public DbSet<SaleModel> Sales { get; set; } = null!;
        public DbSet<ConceptModel> Concepts { get; set; } = null!;
    }
}
