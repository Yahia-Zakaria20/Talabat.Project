using Talabat.Rev.CoreLayer.Entites.OrderAggregate;

namespace Talabat.Rev.Dto
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string PicturUrl { get; set; }

        public int Qunatity { get; set; }

        // public int OrderID { get; set; }  // forignkey  represent Primrykey in OrderTabel [requiered]

        public decimal Price { get; set; }
    }
}
