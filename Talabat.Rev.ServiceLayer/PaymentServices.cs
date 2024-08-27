using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;
using Talabat.Rev.CoreLayer.Specifications.Order_Spec;
using Product = Talabat.Rev.CoreLayer.Entites.Product;

namespace Talabat.Rev.ServiceLayer
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IBasketRepositry _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public PaymentServices(
            IBasketRepositry basketRepo,
            IUnitOfWork unitOfWork,
            IConfiguration configuration
            )
        {
            _basketRepo = basketRepo;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<Order?> ChangeOrderStatuseAsync(string paymentintent, bool Flag)
        {
          var order = await  _unitOfWork.Repositry<Order>().GetByIdAsyncWithSpec(new OrderSpecificationsToGetOrderByPaymentintentId(paymentintent));

            if (Flag == true)
            {
                order.status = OrderStatus.paymentSucceded;
            }
            else 
            {
                order.status = OrderStatus.paymentSucceded;
            }

            _unitOfWork.Repositry<Order>().Update(order);

            await _unitOfWork.CompleteAsync();

            return order;
        }

        public async Task<CustomerBasket?> CreateOrUpdatePaymentIntentAsync(string basketid)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:Secretkey"];

            var basket = await _basketRepo.GetBasketAsync(basketid);

            if (basket is null)
                return null;

            if(basket.Items.Count != 0) 
            {
               foreach  (var item in basket.Items) 
               {
                    var product = await _unitOfWork.Repositry<Product>().GetByIdAsync(item.Id);

                    if(product.Price != item.Price)
                        item.Price = product.Price;
               }
            }
            var deliverymethodprice = 0m;

            if (basket.Delierymethodid.HasValue) 
            {
                var deliverymethod = await _unitOfWork.Repositry<DeliveryMethod>().GetByIdAsync(basket.Delierymethodid.Value);

                deliverymethodprice = deliverymethod.Cost;
            }

            var ToTalPrice = basket.Items.Sum(i => i.Price * 100 * i.Quantity) + deliverymethodprice * 100;

            PaymentIntentService paymentIntentService = new PaymentIntentService();

            if (string.IsNullOrEmpty(basket.Paymentintentid))  //CreatePaymentIntent
            {

                PaymentIntentCreateOptions options = new PaymentIntentCreateOptions()
                {
                    Amount = (long) ToTalPrice,
                    PaymentMethodTypes = new List<string>() { "card"},
                    Currency = "usd"
                };

            


              var paymentIntent =  await   paymentIntentService.CreateAsync(options);


                basket.Paymentintentid = paymentIntent.Id;
                basket.clientSecret = paymentIntent.ClientSecret;

                await _basketRepo.UpdateBasketAsync(basket);
            }
            else // Update Amount For PaymentIntent
            {
                PaymentIntentUpdateOptions options = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)ToTalPrice,
                };

                 await  paymentIntentService.UpdateAsync(basket.Paymentintentid, options);
            }

            return basket;

        }

        
    }
}
