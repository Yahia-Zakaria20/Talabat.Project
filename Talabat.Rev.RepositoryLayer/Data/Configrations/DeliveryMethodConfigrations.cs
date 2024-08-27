using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;

namespace Talabat.Rev.RepositoryLayer.Data.Configrations
{
    internal class DeliveryMethodConfigrations : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> D)
        {
            D.Property(d => d.Cost)
                .HasColumnType("decimal(18,2)");
        }
    }
}
