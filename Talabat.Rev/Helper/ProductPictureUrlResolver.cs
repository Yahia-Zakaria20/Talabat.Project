using AutoMapper;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.Dto;
using static System.Net.WebRequestMethods;

namespace Talabat.Rev.Helper
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            return destination.PictureUrl = $"{_configuration["ApplicationSettings:BaseURL"]}/{source.PictureUrl}";
        }
    }
}
