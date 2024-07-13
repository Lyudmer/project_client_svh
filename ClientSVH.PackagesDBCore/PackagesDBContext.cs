using ClientSVH.PackagesDBCore.Configurations;
using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;


namespace ClientSVH.PackagesDBCore
{
    public class PackagesDBContext(DbContextOptions<PackagesDBContext> options):DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }

        public DbSet<Document> Document { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<StatusGraph> StatusGraph { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new StatusGraphConfiguration());
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
