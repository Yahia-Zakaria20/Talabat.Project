using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites
{
   public class WishlistItem : BaseEntite
   {
        public string UserEmail { get; set; } 

        public int ProductId    { get; set; }

        public Product Product { get; set; } 
       
   }
}
