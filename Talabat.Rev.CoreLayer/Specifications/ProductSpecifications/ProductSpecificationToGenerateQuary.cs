using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace Talabat.Rev.CoreLayer.Specifications.ProductSpecifications
{
    public class ProductSpecificationToGenerateQuary :BaseSpecifications<Product>
    {

        public ProductSpecificationToGenerateQuary(ProductSpecPramas productSpecPramas)
            :base(p => 
                       (!productSpecPramas.brandid.HasValue || p.BrandId == productSpecPramas.brandid) && 
                       (!productSpecPramas.catogaryid.HasValue || p.CategoryId == productSpecPramas.catogaryid) &&
                       (string.IsNullOrEmpty(productSpecPramas.Name) || p.Name.ToUpper().Contains(productSpecPramas.Name))
                 )
        {
            Includs();

            if (!string.IsNullOrEmpty(productSpecPramas.sorting))
            {
                switch (productSpecPramas.sorting)
                {
                    case "priceAsc":
                       AddOrderBy(OrderBy = p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDesc(OrderByDesc = p => p.Price);
                        break;

                    default:
                        AddOrderBy(OrderBy = p => p.Name);
                        break;
                } 
            }
            else
            {
                AddOrderBy(OrderBy = p => p.Name);
            }

            AplayPagination(productSpecPramas.PageSize, productSpecPramas.pageindex);
          
        }

       

        public ProductSpecificationToGenerateQuary(int id) : 
            base(p => p.Id == id)
        {
            Includs();
        }


        private void Includs()
        {
            base.Includs.Add(p => p.ProductBrand);
            base.Includs.Add(p => p.ProductCategory);
        }




    }
}
