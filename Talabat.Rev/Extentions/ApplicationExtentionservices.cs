using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Talabat.Rev.CoreLayer;
using Talabat.Rev.CoreLayer.Entites.IdentityData;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;
using Talabat.Rev.Errors;
using Talabat.Rev.Helper;
using Talabat.Rev.RepositoryLayer;
using Talabat.Rev.RepositoryLayer.Data;
using Talabat.Rev.RepositoryLayer.Identity;
using Talabat.Rev.ServiceLayer;

namespace Talabat.Rev.Extentions
{
    public static class ApplicationExtentionservices
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection webApplicationBuilder) 
        {
            //  webApplicationBuilder.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepositry<>));

            webApplicationBuilder.AddScoped<IUnitOfWork, UnitOfwork>();
            webApplicationBuilder.AddScoped<IPaymentServices, PaymentServices>();
            webApplicationBuilder.AddScoped<IAuthServices, AuthServices>();
            webApplicationBuilder.AddSingleton<ICachadResponseService, CachadResponseService>();
            webApplicationBuilder.AddScoped<IOrderServices,OrderServices>();

            webApplicationBuilder.AddScoped<IBasketRepositry, BasketRepositry>();
            webApplicationBuilder.AddScoped<IProductServices,ProductServices>();

            webApplicationBuilder.AddTransient<ProductPictureUrlResolver>();
            webApplicationBuilder.AddTransient<OrderStatusResolver>();

            webApplicationBuilder.AddTransient<ProductitemorderPictureURlResolver>();


            webApplicationBuilder.AddAutoMapper(o => o.AddProfile(new MappingProfile()));

            webApplicationBuilder.Configure<ApiBehaviorOptions>(option => {

                option.InvalidModelStateResponseFactory = (actiocontext) =>
                {

                    var errors = actiocontext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                   .SelectMany(e => e.Value.Errors)
                                                    .Select(p => p.ErrorMessage)
                                                     .ToList();

                    var ApiValidationError = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(ApiValidationError);
                };


            });
            return webApplicationBuilder;
        }


        public static IServiceCollection AddSwaggerServices(this IServiceCollection webApplicationBuilder) 
        {

            webApplicationBuilder.AddEndpointsApiExplorer();
            webApplicationBuilder.AddSwaggerGen();


            return webApplicationBuilder;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection webApplicationBuilder, IConfiguration configuration)
        {

            webApplicationBuilder.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
            })
              .AddEntityFrameworkStores<IdentityStoreDbContext>();


            webApplicationBuilder.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
              { 
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidAudience = configuration["Jwt:Audience"],
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"])),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromDays(double.Parse(configuration["Jwt:Expire"]))
                    };
                   
              });

            return webApplicationBuilder;
        }
    }
}
