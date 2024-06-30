using ClientSVH.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.DataAccess.Configurations
{
    public class PackageConfiguration:IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(p => p.Id);
            builder
                .HasOne(p => p.Status)
                .WithOne(s => s.Package)
                .HasForeignKey<Status>(s => s.Id);

            builder
                .HasMany(p => p.Documents)
                .WithOne(d => d.Package)
                .HasForeignKey(d=>d.Pid);
        }
    }
}
