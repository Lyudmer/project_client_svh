using ClientSVH.DataAccess.Configurations;
using ClientSVH.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;


namespace ClientSVH.DataAccess
{
    public class PackagesDBContext(DbContextOptions<PackagesDBContext> options):DbContext(options)
    {

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
