using CodeDesignPlus.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDesignPlus.InMemory
{
    public class CodeDesingPlusContextInMemory : DbContext
    {
        public CodeDesingPlusContextInMemory (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Application> Application { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<AppPermission> AppPermission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
    }
}
