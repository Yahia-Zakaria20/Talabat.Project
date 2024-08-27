using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites.OrderAggregate
{
    public class OrderItem : BaseEntite
    {
        public ProductItemOrder ProductItemOrder { get; set; }

        public int Qunatity { get; set; }

       // public int OrderID { get; set; }  // forignkey  represent Primrykey in OrderTabel [requiered]

        public decimal Price { get; set; }


        public OrderItem()
        {

        }
        public OrderItem(ProductItemOrder productItemOrder, int qunatity, decimal price)
        {
            ProductItemOrder = productItemOrder;
            Qunatity = qunatity;
            Price = price;
        }

    }
}
