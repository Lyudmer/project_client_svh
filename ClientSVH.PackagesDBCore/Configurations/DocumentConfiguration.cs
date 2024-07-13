﻿using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientSVH.PackagesDBCore.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("documents");
            //ключи
            builder.HasKey(d => d.Id);
            builder
                .HasOne(p => p.Package)
                .WithMany(d => d.Documents)
                .HasForeignKey(d => d.Id);
            //свойства полей
            builder.Property(d => d.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd()
                   .HasColumnName("did")
                   .HasColumnType("bigint");

            builder.Property(d => d.Pid)
                   .IsRequired()
                   .HasColumnName("pid");

            builder.Property(d => d.CreateDate)
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("now()");

            builder.Property(d => d.ModifyDate)
                    .HasColumnName("modify_date");

            builder.Property(d => d.Number)
                    .HasColumnName("number")
                    .HasMaxLength(50);
            builder.Property(d => d.ModeCode)
                    .HasColumnName("modecode")
                    .HasMaxLength(5);
            builder.Property(d => d.DocDate)
                    .HasColumnName("docdate")
                    .HasMaxLength(5);
            builder.Property(d => d.SizeDoc)
                    .IsRequired()
                    .HasColumnName("size_doc");
            builder.Property(d => d.Idmd5)
                   .IsRequired()
                   .HasColumnName("idmd5")
                   .HasMaxLength(32);
            builder.Property(d => d.IdSha256)
                   .IsRequired()   
                   .HasColumnName("idsha256")
                   .HasMaxLength(64);
        }
    }
}
