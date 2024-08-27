using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites.OrderAggregate
{
   public enum OrderStatus
   {
     [EnumMember(Value = "Pending")]  // this Value will saved in database 
        Pending,
     [EnumMember(Value = "Payment Failed")] // this Value will saved in database 
        PaymentFailed,
     [EnumMember(Value = "payment Succeded")] // this Value will saved in database 
        paymentSucceded
   }
   
   
   
}
