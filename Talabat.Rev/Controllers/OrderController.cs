using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;
using Talabat.Rev.Dto;
using Talabat.Rev.Errors;

namespace Talabat.Rev.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : BaseApiController
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;

        public OrderController(IOrderServices orderServices,
            IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto dto)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);


            var Shippingaddress = _mapper.Map<shippingaddreesDto, Address>(dto.shippingaddress);

            var Order = await _orderServices.CreateOrderAsync(Email, dto.deliveryMethodId, dto.basketid, Shippingaddress);

            if (Order is null)
                return BadRequest(new ApiResponse(400));

            return Ok(_mapper.Map<Order , OrderToReturnDto>(Order));
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrdersForUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var orders = await _orderServices.GetAllOrdersForUserAsync(email);

            if(orders is null)
                BadRequest(new ApiResponse(400));

            return Ok(_mapper.Map<IReadOnlyList<Order>,IReadOnlyList< OrderToReturnDto>>(orders)); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderForUser([Required]int id) 
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var order = await _orderServices.GetOrderByIdforUserAsync(id , email);
            if(order is null)
                NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Order, OrderToReturnDto>(order));
        }
         
        [HttpGet("deliverymethod")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMthods() 
        {
          var result = await  _orderServices.GetAllDeliveryMethodsAsync();

           return Ok(result);
        }
    }
}
