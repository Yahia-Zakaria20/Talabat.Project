using AutoMapper;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.Dto;

namespace Talabat.Rev.Helper
{
    public class ProductitemorderPictureURlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;
        public ProductitemorderPictureURlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            return destination.PicturUrl = $"{_configuration["ApplicationSettings:BaseURL"]}/{source.ProductItemOrder.PicturUrl}";
        }
    }
}
