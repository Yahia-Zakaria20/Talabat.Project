using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Claims;
using Talabat.Rev.CoreLayer;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Specifications;
using Talabat.Rev.Dto;
using Talabat.Rev.Errors;

namespace Talabat.Rev.Controllers
{

    public class WishlistItemController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WishlistItemController(IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProductsFromListByuserEmail()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var result = await _unitOfWork.WishlistRepo.GetAllProductForUserByEmailAsync(email);
            if (result is null)
                return NotFound(new ApiResponse(404));


            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(result));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{productid}")]
        public async Task<ActionResult> AddToWishlist(int productid)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var obj = new WishlistItem()
            {
                ProductId = productid,
                UserEmail = email
            };

            await _unitOfWork.WishlistRepo.AddAsync(obj);

            var result = await _unitOfWork.CompleteAsync();

            if (result > 0)
                return Ok();

            return BadRequest(new ApiResponse(404));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{productid}")]
        public async Task<ActionResult> DeleteProductfromWishlist(int productid)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

         var Wishlistobj =   await  _unitOfWork.WishlistRepo.GetWishlistobjAsync(email, productid);

              _unitOfWork.WishlistRepo.Delet(Wishlistobj);

            var result = await _unitOfWork.CompleteAsync();

            if (result > 0)
                return Ok();

            return BadRequest(new ApiResponse(404));

        }


    }
}
