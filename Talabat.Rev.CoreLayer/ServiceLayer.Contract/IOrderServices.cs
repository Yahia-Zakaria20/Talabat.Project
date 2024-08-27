using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;

namespace Talabat.Rev.CoreLayer.ServiceLayer.Contract
{
    public interface IOrderServices
    {
        Task<Order?> CreateOrderAsync(string buyeremail, int deliverymthod, string basketid,Address address);

        Task<IReadOnlyList<Order>> GetAllOrdersForUserAsync(string buyerEmail);

        Task<Order?>GetOrderByIdforUserAsync(int orderid ,string  buyerEmail);

        Task<IReadOnlyList<DeliveryMethod>> GetAllDeliveryMethodsAsync();
    }
}
