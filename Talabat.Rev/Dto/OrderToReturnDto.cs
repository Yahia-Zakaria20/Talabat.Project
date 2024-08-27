using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;

namespace Talabat.Rev.Dto
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }

        public string BuyerEmail { get; set; } 

        public DateTimeOffset OrderTime { get; set; }

        public string status { get; set; } 

        public Address ShippingAddress { get; set; } 

        public string deliveryMethod { get; set; }

        public decimal Cost { get; set; }

        public ICollection<OrderItemDto> Items { get; set; } = new HashSet<OrderItemDto>();

        public decimal SubTotal { get; set; } // total product prices (product price * Product Quantity) and  Summiton all

        public decimal Total { get; set; } // drived attribute may be in order dtos or make method getter

        public string PaymentIntentId { get; set; } = string.Empty;
    }
}
