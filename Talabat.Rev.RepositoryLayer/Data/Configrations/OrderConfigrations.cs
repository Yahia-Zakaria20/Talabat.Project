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
    internal class OrderConfigrations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> O)
        {
            O.OwnsOne(o => o.ShippingAddress, shippingaddress => shippingaddress.WithOwner());


            O.Property(o => o.status)
                .HasConversion(s => s.ToString(),
               s => (OrderStatus) Enum.Parse(typeof(OrderStatus),s));


            O.HasOne(o => o.deliveryMethod)
                .WithMany()
                .HasForeignKey(o => o.DeliveryMethodId)
                .OnDelete(DeleteBehavior.SetNull);
              

           

            O.HasMany(o => o.Items)
                .WithOne();

            O.Property(o => o.SubTotal)
                .HasColumnType("decimal(18,2)");
        }
    }
}
