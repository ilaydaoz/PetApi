using Microsoft.EntityFrameworkCore;
using Pet.Core.Domain.Entities;

namespace Pet.Infrastructure.Context
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp").Entity<User>().Property(a => a.Id).HasDefaultValueSql("uuid_generate_v4()").ValueGeneratedOnAdd();
            modelBuilder.HasPostgresExtension("uuid-ossp").Entity<Category>().Property(a => a.Id).HasDefaultValueSql("uuid_generate_v4()").ValueGeneratedOnAdd();
        }
    }
}
