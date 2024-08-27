using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace Talabat.Rev.CoreLayer.Specifications.ProductSpecifications
{
    public class ProductSpecToCalcCount : BaseSpecifications<Product>
    {

        public ProductSpecToCalcCount(ProductSpecPramas productSpecPramas) : 
            base(p =>
                       (!productSpecPramas.brandid.HasValue || p.BrandId == productSpecPramas.brandid) &&
                       (!productSpecPramas.catogaryid.HasValue || p.CategoryId == productSpecPramas.catogaryid) &&
                       (string.IsNullOrEmpty(productSpecPramas.Name) || p.Name.ToUpper().Contains(productSpecPramas.Name))
                 )
        {

        }
    }
}
