using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;
using Talabat.Rev.Errors;

namespace Talabat.Rev.Controllers
{
   
    public class PaymentController :BaseApiController
    {
        private readonly IPaymentServices _paymentServices;

        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{basketid}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePayemntIntent(string basketid) 
        {
            var result = await _paymentServices.CreateOrUpdatePaymentIntentAsync(basketid);

            if (result is null)
                return BadRequest(new ApiResponse(400));


            return Ok(result);
        }


        [HttpPost("webhook")]
        public async Task<IActionResult> StripeWebHook() 
        {
            const string endpointSecret = "whsec_cc1950828342baa5547942e4a065d8b01caad4241bffa96b984cc1bdf8edeec5";

            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
           
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

           var paymentIntent =(PaymentIntent)  stripeEvent.Data.Object;  // to get paymentintentid to search by it to get order to change the order status
            // Handle the event
            if (stripeEvent.Type == Events.PaymentIntentPaymentFailed)
            {
                await _paymentServices.ChangeOrderStatuseAsync(paymentIntent.Id, true);
            }
            else if (stripeEvent.Type == Events.PaymentIntentSucceeded)
            {
                await _paymentServices.ChangeOrderStatuseAsync(paymentIntent.Id, false);
            }

                return Ok();
        }
    }
}
