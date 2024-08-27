using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites.OrderAggregate
{
    public class DeliveryMethod :BaseEntite
    {
      
        public string ShortName { get; set; }

        public string Description { get; set; }

        public string  DeliveryTime { get; set; }

        public decimal Cost { get; set; }

        public DeliveryMethod()
        {

        }


        public DeliveryMethod(string shortName, string description, string deliveryTime, decimal cost)
        {
            ShortName = shortName;
            Description = description;
            DeliveryTime = deliveryTime;
            Cost = cost;
        }

       
    }
}
