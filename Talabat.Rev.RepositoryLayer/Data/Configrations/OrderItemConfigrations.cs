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
    internal class OrderItemConfigrations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem>O)
        {
            O.OwnsOne(o => o.ProductItemOrder, product => product.WithOwner());

            O.Property(o => o.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
