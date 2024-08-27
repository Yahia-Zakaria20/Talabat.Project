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
    internal class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> P)
        {
            P.Property(p => p.Name)
                .IsRequired();

            P.Property(p => p.PictureUrl)
                .IsRequired();

            P.Property(p => p.Description)
                .IsRequired();


            P.HasOne(p => p.ProductBrand)
                .WithMany()
                .IsRequired()
                .HasForeignKey(p => p.BrandId);

            P.HasOne(p => p.ProductCategory)
              .WithMany()
              .IsRequired()
              .HasForeignKey(p => p.CategoryId);
        }
    }
}
