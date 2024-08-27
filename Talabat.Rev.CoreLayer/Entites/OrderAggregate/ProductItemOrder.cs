using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites.OrderAggregate
{
    public class ProductItemOrder
    {
        public ProductItemOrder()
        {
        }

        public ProductItemOrder(int productId, string productName, string picturUrl)
        {
            ProductId = productId;
            ProductName = productName;
            PicturUrl = picturUrl;
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string PicturUrl { get; set; }
    }
}
