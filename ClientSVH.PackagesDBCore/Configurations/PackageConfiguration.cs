using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.PackagesDBCore.Configurations
{
    public class PackageConfiguration:IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("packages");
//ключи
            builder.HasKey(p => p.Id);
            builder
                .HasOne(p => p.Status)
                .WithOne(s => s.Package)
                .HasForeignKey<Status>(s => s.Id);

            builder
                .HasMany(p => p.Documents)
                .WithOne(d => d.Package)
                .HasForeignKey(d=>d.Pid);
//свойства полей
            builder.Property(p => p.Id)
                   .IsRequired()   
                   .ValueGeneratedOnAdd()
                   .HasColumnName("pid")
                   .HasColumnType("bigint");

            builder.Property(p => p.CreateDate)
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("now()");

            builder.Property(p => p.ModifyDate)
                    .HasColumnName("modify_date");
            

            builder.Property(p => p.StatusId)
                   .HasDefaultValue("0")
                   .HasColumnName("status");

            builder.Property(p => p.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

                   

        }
    }
}
