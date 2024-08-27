using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;

namespace Talabat.Rev.CoreLayer.Specifications.Order_Spec
{
    public class OrderSpecificationsToGetOrderByPaymentintentId:BaseSpecifications<Order>
    {
        public OrderSpecificationsToGetOrderByPaymentintentId(string PaymentIntentId)
            :base(o => o.PaymentIntentId == PaymentIntentId)
        {
            
        }
    }
}
