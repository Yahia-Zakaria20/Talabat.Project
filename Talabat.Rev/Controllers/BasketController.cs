using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;
using Talabat.Rev.Dto;
using Talabat.Rev.Errors;

namespace Talabat.Rev.Controllers
{
  
    public class BasketController :  BaseApiController
    {
        private readonly IBasketRepositry _basketRepositry;
        private readonly IMapper _mapper;

        public BasketController(
            IBasketRepositry basketRepositry
            ,IMapper mapper) //Scoped
        {
            _basketRepositry = basketRepositry;
            _mapper = mapper;
        }


        [HttpGet] //Get :api/Basket
        public async Task<ActionResult<CustomerBasket>> GetUserBasket(string id) 
        {

            var basket = await _basketRepositry.GetBasketAsync(id);

          return Ok (basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket) 
        {
            var model =  _mapper.Map<CustomerBasketDto,CustomerBasket>(basket);

            var Basket = await  _basketRepositry.UpdateBasketAsync(model);
            if (Basket is null)
                return BadRequest(new ApiResponse(400));
            
            return Ok(Basket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string id) 
        {
           await  _basketRepositry.DeleteBasketAsync(id);
        }


    }
}
