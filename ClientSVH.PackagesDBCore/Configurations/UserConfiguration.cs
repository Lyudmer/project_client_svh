using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.PackagesDBCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
//ключи
            builder.HasKey(u => u.Id);
            builder
                .HasMany(u => u.Packages)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
//свойства полей

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .HasColumnType("bigint");

            builder.Property(u => u.Login)
                .HasMaxLength(100)
                .HasColumnName("login")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("password");

            builder.Property(u => u.FullName)
                .HasMaxLength(200)
                .HasColumnName("fullname");

            builder.Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("email");

            builder.Property(u => u.CreateDate)
                .HasColumnName("create_date")
                .HasDefaultValueSql("now()");  

            builder.Property(u => u.ModifyDate)
                .HasColumnName("modify_date");

            builder.Property(u => u.Hidden)
                .HasColumnName("hidden")
                .HasDefaultValue(false);

        }
    }
}
