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

namespace Talabat.Rev.ServiceLayer
{
    public class OrderServices : IOrderServices
    {
        private readonly IBasketRepositry _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentServices _paymentServices;

        ///private readonly IGenericRepositry<Product> _ProductRepo;
        ///private readonly IGenericRepositry<DeliveryMethod> _deliverymethodRepo;
        ///private readonly IGenericRepositry<Order> _orderRepo;

        public OrderServices(
            IBasketRepositry basketRepo,
            ///IGenericRepositry<Product> ProductRepo,
            ///IGenericRepositry<DeliveryMethod> deliverymethodRepo,
            ///IGenericRepositry<Order> OrderRepo
            IUnitOfWork unitOfWork,
            IPaymentServices paymentServices) 
        {
            _basketRepo = basketRepo;
            _unitOfWork = unitOfWork;
           _paymentServices = paymentServices;
            ///_ProductRepo = ProductRepo;
            ///_deliverymethodRepo = deliverymethodRepo;
            ///_orderRepo = OrderRepo;
        }

        public async Task<Order?> CreateOrderAsync(string buyeremail, int deliverymthodid, string basketid, Address address)
        {
            //1.get Basket From BasketRepo
            var basket = await _basketRepo.GetBasketAsync(basketid);
            if (basket is not null)
            {
                //2.get Selected item From ProductRepo
                var OrderItems = new List<OrderItem>();

                if (basket?.Items?.Count > 0)
                {
                    var productrepo =  _unitOfWork.Repositry<Product>();
                    foreach (var item in basket.Items)
                    {
                        var product = await productrepo.GetByIdAsync(item.Id);

                        var productitemorder = new ProductItemOrder(product.Id, product.Name, product.PictureUrl);

                        var Orderitem = new OrderItem(productitemorder, item.Quantity, product.Price);

                        OrderItems.Add(Orderitem);
                    }
                }
                //3.Clac Subtotal

                var subtotal = OrderItems.Sum(O => O.Qunatity * O.Price);

                //4.get Deliverymethod From Deliverymethodrepo

               var deliverymethod = await _unitOfWork.Repositry<DeliveryMethod>().GetByIdAsync(deliverymthodid);

                //5. Create Order 

                var _orderrepo = _unitOfWork.Repositry<Order>();

                var result = await  _orderrepo.GetByIdAsyncWithSpec(new OrderSpecificationsToGetOrderByPaymentintentId(basket.Paymentintentid));

                if (result is not null) 
                {
                    _orderrepo.Delet(result);

                    await  _paymentServices.CreateOrUpdatePaymentIntentAsync(basket.Id);

                }


                var order = new Order(buyeremail, address, deliverymethod.Id, OrderItems, subtotal,basket.Paymentintentid);

                await _orderrepo.AddAsync(order);

                //6. Save To DataBase
                var roweffect = await _unitOfWork.CompleteAsync();
                if (roweffect <= 0)
                    return null;

                return order;
            }
            else 
            {
                return null;
            }
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetAllDeliveryMethodsAsync()
             => await _unitOfWork.Repositry<DeliveryMethod>().GetAllAsync();
        

        public async Task<IReadOnlyList<Order>> GetAllOrdersForUserAsync(string buyerEmail)
        {
            //var spec = new OrderSpecifications(buyerEmail);
            //var OrderRepo = _unitOfWork.Repositry<Order>();
            //var orders =  OrderRepo.GetAllAsyncWithSpec(spec);

            return await _unitOfWork.Repositry<Order>().GetAllAsyncWithSpec(new OrderSpecifications(buyerEmail));
        }

        public async Task<Order?> GetOrderByIdforUserAsync(int orderid, string buyerEmail)
        {
            //var spec =new OrderSpecifications(buyerEmail, orderid) ;
            //var OrderRepo = _unitOfWork.Repositry<Order>();
            //var orders = OrderRepo.GetByIdAsyncWithSpec(spec);

            return await _unitOfWork.Repositry<Order>().GetByIdAsyncWithSpec(new OrderSpecifications(buyerEmail, orderid));
        }
    }
}
