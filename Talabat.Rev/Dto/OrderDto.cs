using System.ComponentModel.DataAnnotations;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.CustomAttribute;

namespace Talabat.Rev.Dto
{
    public class OrderDto
    {
     
      [Required]
      [NotZero]
      public   int deliveryMethodId { get; set; }

      public shippingaddreesDto shippingaddress { get; set; }

      [Required]
      public string basketid { get; set; }
    }
}
