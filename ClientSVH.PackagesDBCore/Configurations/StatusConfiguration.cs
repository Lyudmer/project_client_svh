using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.PackagesDBCore.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("pkg_status");
   //ключи
            builder.HasKey(s => s.Id);
            builder
                .HasOne(p => p.Package)
                .WithOne(s => s.Status)
               .HasForeignKey<Package>(p => p.Id);
  //свойства полей
            builder.Property(s => s.Id)
                   .IsRequired()
                   .HasColumnName("id");
            builder.Property(s => s.FullName)
                   .HasColumnName("fullname")
                   .HasMaxLength(250);
            builder.Property(s => s.MkRes)
                   .HasColumnName("mkres")
                   .HasDefaultValue(false);
            builder.Property(s => s.RunWf)
                   .HasColumnName("runwf")
                   .HasDefaultValue(false);
        }
    }
}
