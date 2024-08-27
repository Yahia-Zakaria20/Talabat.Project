using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites.OrderAggregate
{
    public class Order :BaseEntite
    {
        public Order()
        {
        }

        public Order(string buyerEmail, Address shippingAddress, int deliveryMethodid, ICollection<OrderItem> items, decimal subTotal, string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethodId = deliveryMethodid;
            Items = items;
            SubTotal = subTotal;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyerEmail { get; set; } // UserEmail he Is create Order

        public DateTimeOffset OrderTime { get; set; } = DateTimeOffset.UtcNow;

        public OrderStatus status { get; set; } = OrderStatus.Pending;

        public Address ShippingAddress { get; set; }

        public DeliveryMethod deliveryMethod { get; set; }

        public int? DeliveryMethodId { get; set; } //ForgingKey reprsernt Deliverymethod order

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

        public decimal SubTotal { get; set; } // total product prices (product price * Product Quantity) and  Summiton all

        [NotMapped]
        public decimal Total => deliveryMethod.Cost + SubTotal; // drived attribute may be in order dtos or make method getter

        //public decimal GetTotal()
        //    => deliveryMethod.Cost + SubTotal; this another way t calc or make derived attribute


        public  string PaymentIntentId { get; set; } 
    }
}
