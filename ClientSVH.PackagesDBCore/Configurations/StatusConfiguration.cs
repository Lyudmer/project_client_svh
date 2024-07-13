using ClientSVH.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.DataAccess.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.Id);
            builder
                .HasOne(p => p.Package)
                .WithOne(s => s.Status)
               .HasForeignKey<Package>(p => p.Id);
        }
    }
}
