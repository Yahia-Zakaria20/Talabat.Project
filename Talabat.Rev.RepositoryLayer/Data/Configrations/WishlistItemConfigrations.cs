using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace Talabat.Rev.RepositoryLayer.Data.Configrations
{
   public class WishlistItemConfigrations : IEntityTypeConfiguration<WishlistItem>
   {
        public void Configure(EntityTypeBuilder<WishlistItem> w)
        {
            w.HasOne(w => w.Product)
                 .WithMany()
                 .HasForeignKey(w => w.ProductId);

            w.Property(w => w.ProductId)
                 .IsRequired();

            w.Property(w => w.UserEmail)
                .IsRequired();
        }
   }
}
