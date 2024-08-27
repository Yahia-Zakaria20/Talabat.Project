using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;
using Talabat.Rev.CoreLayer.Specifications;
using Talabat.Rev.CoreLayer.Specifications.ProductSpecifications;

namespace Talabat.Rev.ServiceLayer
{
   public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductServices(IUnitOfWork unitOfWork) 
        {
         
            _unitOfWork = unitOfWork;
        }


        public async Task<IReadOnlyList<Product>> GetAllProductAsync(ProductSpecPramas productSpecPramas)
        {
            var spec = new ProductSpecificationToGenerateQuary(productSpecPramas);

            var product = await  _unitOfWork.Repositry<Product>().GetAllAsyncWithSpec(spec);

            return product;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandAsync()
        => await _unitOfWork.Repositry<ProductBrand>().GetAllAsync();

        public async Task<IReadOnlyList<ProductCategory>> GetAllProductCategoryAsync()
        => await _unitOfWork.Repositry<ProductCategory>().GetAllAsync();

        public async Task<int> GetCountAsync(ProductSpecPramas productSpecPramas)
        {
            var specTocalcCount = new ProductSpecToCalcCount(productSpecPramas);

            return  await _unitOfWork.Repositry<Product>().GetCountAsync(specTocalcCount);
        }


        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var spec = new ProductSpecificationToGenerateQuary(id);
            var Product = await _unitOfWork.Repositry<Product>().GetByIdAsyncWithSpec(spec);
               return Product;   
        }
    }
}
