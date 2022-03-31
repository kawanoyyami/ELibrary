using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.EFConfiguration
{
    internal class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(r => r.Name)
                .IsRequired();

            builder.Property(r => r.Link)
                .IsRequired();

            builder.Property(r => r.CreatedDate)
                .IsRequired();

            builder.HasOne(r => r.Project)
                .WithMany(p => p.Reports)
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(r => r.RowVersion)
                .IsRowVersion();
        }
    }
}
