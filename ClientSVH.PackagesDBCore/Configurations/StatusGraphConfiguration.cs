using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.PackagesDBCore.Configurations
{
    public class StatusGraphConfiguration : IEntityTypeConfiguration<StatusGraph>
    {
        
        public void Configure(EntityTypeBuilder<StatusGraph> builder)
        {
            builder.ToTable("pkg_status_graph");
    //ключи
            builder.HasKey(st => st.oldst);
            builder
                .HasOne(s => s.Status)
                .WithOne(st => st.StatusGraph)
                .HasForeignKey<Status>(st => st.oldst);
            //свойства полей
            builder.Property(st => st.oldst)
                   .IsRequired();
            builder.Property(st => st.newst)
                   .IsRequired();
            builder.Property(st => st.maskbit)
                   .HasMaxLength(10);

        }
    }
}
