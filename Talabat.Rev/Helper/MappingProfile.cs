using AutoMapper;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.Dto;

namespace Talabat.Rev.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(P => P.BrandName, O => O.MapFrom(P => P.ProductBrand.Name))
               .ForMember(P => P.CategoryName, O => O.MapFrom(P => P.ProductCategory.Name))
               .ForMember(P => P.CategoryName, O => O.MapFrom<ProductPictureUrlResolver>());

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemsDto, BasketItems>();
            CreateMap<shippingaddreesDto,Talabat.Rev.CoreLayer.Entites.OrderAggregate.Address>();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(o => o.deliveryMethod, o => o.MapFrom(o => o.deliveryMethod.ShortName))
                .ForMember(o => o.Cost, o => o.MapFrom(o => o.deliveryMethod.Cost))
                .ForMember(o => o.status , o => o.MapFrom<OrderStatusResolver>());

            CreateMap<OrderItem, OrderItemDto>()
                 .ForMember(o => o.ProductName, o => o.MapFrom(o => o.ProductItemOrder.ProductName))
                 .ForMember(o => o.PicturUrl , o => o.MapFrom<ProductitemorderPictureURlResolver>())
                 .ForMember(o => o.ProductId, o => o.MapFrom(o => o.ProductItemOrder.ProductId));


            CreateMap<AddressDto,Talabat.Rev.CoreLayer.Entites.IdentityData.Address>().ReverseMap();   
        }
    }
}
