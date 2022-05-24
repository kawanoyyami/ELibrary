using Domain.Models.Subscriptio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFConfiguration
{
    internal class SubscriptionConfiguration : IEntityTypeConfiguration<Subscriptionn>
    {
        public void Configure(EntityTypeBuilder<Subscriptionn> builder)
        {

        }
    }
}
