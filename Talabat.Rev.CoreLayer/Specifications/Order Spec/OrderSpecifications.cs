using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;

namespace Talabat.Rev.CoreLayer.Specifications.Order_Spec
{
    public class OrderSpecifications:BaseSpecifications<Order>
    {

        public OrderSpecifications(string email)
            :base(o => o.BuyerEmail == email) 
        {

            Includes();

            AddOrderByDesc(o => o.OrderTime);
        }

        public OrderSpecifications(string email , int orderid)
            :base(o => o.BuyerEmail == email  && o.Id == orderid)
        {
            Includes();
        }

        private void Includes()
        {
            Includs.Add(o => o.deliveryMethod);
            Includs.Add(o => o.Items);
        }
    }
}
