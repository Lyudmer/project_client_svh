using ClientSVH.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder
                .HasMany(u => u.Packages)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}
