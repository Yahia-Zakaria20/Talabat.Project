using Talabat.Rev.CoreLayer.Entites;

namespace Talabat.Rev.Dto
{
    public class CustomerBasketDto
    {
        public string Id { get; set; }

        public string? Paymentintentid { get; set; }

        public string? clientSecret { get; set; }

        public int? Delierymethodid { get; set; }

        public IReadOnlyList<BasketItemsDto> Items { get; set; }
    }
}
