﻿using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.EFConfiguration
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.DOB)
                .IsRequired();

            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(32);

            //builder.HasMany(a => a.Books)
            //    .WithMany(b => b.Authors)
            //    .UsingEntity(j => j.ToTable("AuthorBook"));

            builder.HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthorBook",
                    j => j
                         .HasOne<Book>()
                         .WithMany()
                         .HasForeignKey("BookId")
                         .HasConstraintName("FK_AuthorBook_Books_BookId")
                         .OnDelete(DeleteBehavior.Cascade),
                    j => j
                         .HasOne<Author>()
                         .WithMany()
                         .HasForeignKey("AuthorId")
                         .HasConstraintName("FK_AuthorBook_Authors_AuthorId")
                         .OnDelete(DeleteBehavior.ClientCascade));

            builder.Property(a => a.RowVersion)
                .IsRowVersion();
        }
    }
}
