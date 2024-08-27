using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Specifications;
using Talabat.Rev.CoreLayer.Specifications.ProductSpecifications;

namespace Talabat.Rev.CoreLayer.ServiceLayer.Contract
{
    public interface IProductServices
    {

        public Task<IReadOnlyList<Product>> GetAllProductAsync(ProductSpecPramas productSpecPramas);

        public Task<Product?> GetProductByIdAsync(int id);

        public Task<int> GetCountAsync(ProductSpecPramas productSpecPramas);
        public Task<IReadOnlyList<ProductBrand>> GetAllProductBrandAsync();

        public Task<IReadOnlyList<ProductCategory>> GetAllProductCategoryAsync();





    }
}
