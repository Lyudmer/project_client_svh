using ClientSVH.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.DataAccess.Configurations
{
    public class StatusGraphConfiguration : IEntityTypeConfiguration<StatusGraph>
    {
        public void Configure(EntityTypeBuilder<StatusGraph> builder)
        {
            builder.HasKey(st => st.oldst);
            builder
                .HasOne(s => s.Status)
                .WithOne(st => st.StatusGraph)
                .HasForeignKey<Status>(st => st.oldst);

        }
    }
}
