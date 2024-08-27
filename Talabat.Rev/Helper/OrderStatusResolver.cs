using AutoMapper;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.Dto;

namespace Talabat.Rev.Helper
{
    public class OrderStatusResolver : IValueResolver<Order, OrderToReturnDto, string>
    {
        public string Resolve(Order source, OrderToReturnDto destination, string destMember, ResolutionContext context)
        {
          return  destination.status = source.status.ToString();
        }
    }
}
