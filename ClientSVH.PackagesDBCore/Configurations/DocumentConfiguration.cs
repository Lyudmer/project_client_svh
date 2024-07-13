using ClientSVH.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.DataAccess.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(d => d.Id);
            builder
                .HasOne(p => p.Package)
                .WithMany(d => d.Documents)
                .HasForeignKey(d => d.Id);
        }
    }
}
