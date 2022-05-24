using Domain.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFConfiguration
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.RowVersion)
                .IsRowVersion();

            builder.Property(b => b.IsFree)
                .HasDefaultValue(true);

            builder.Property(b => b.AmazonLink)
                .HasDefaultValue("https://www.google.com/");
        }
    }
}
