using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;
using Talabat.Rev.CoreLayer.Specifications.ProductSpecifications;
using Talabat.Rev.Dto;
using Talabat.Rev.Errors;
using Talabat.Rev.Helper;
using Talabat.Rev.RepositoryLayer;

namespace Talabat.Rev.Controllers
{
	
	public class ProductController : BaseApiController
	{
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductController(
            IProductServices productServices,
             IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetAllProduct([FromQuery]ProductSpecPramas productSpecPramas) 
        {
          
             var product = await _productServices.GetAllProductAsync(productSpecPramas);

             var producttoreturnDto = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(product);

            var count = await _productServices.GetCountAsync(productSpecPramas);

            return Ok(new Pagination<ProductToReturnDto>(productSpecPramas.PageSize ,productSpecPramas.pageindex , count , producttoreturnDto));
        }


        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await _productServices.GetProductByIdAsync(id);
            if (product is null)
                return BadRequest(new ApiResponse(400));
            return Ok(_mapper.Map<Product,ProductToReturnDto>(product));
        }



        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands() 
        {
            var Brands = await _productServices.GetAllProductBrandAsync();
            return Ok(Brands);
        }



        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetCategory()
        {
            var categories =await _productServices.GetAllProductCategoryAsync();  

            return Ok(categories);
        }

    }
}
