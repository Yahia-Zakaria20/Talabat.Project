using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;

namespace Talabat.Rev.CoreLayer.ServiceLayer.Contract
{
    public interface IPaymentServices
    {
       Task<Order?> ChangeOrderStatuseAsync(string paymentintent, bool Flag);
        Task<CustomerBasket?> CreateOrUpdatePaymentIntentAsync(string basketid);
    }
}
