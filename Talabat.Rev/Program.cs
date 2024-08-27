using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Entites.IdentityData;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;
using Talabat.Rev.Errors;
using Talabat.Rev.Extentions;
using Talabat.Rev.Helper;
using Talabat.Rev.Middlewares;
using Talabat.Rev.RepositoryLayer;
using Talabat.Rev.RepositoryLayer.Data;
using Talabat.Rev.RepositoryLayer.Identity;

namespace Talabat.Rev
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            #region Configer Services
            // Add services to the container.

            webApplicationBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            webApplicationBuilder.Services.AddSwaggerServices();

            webApplicationBuilder.Services.AddDbContext<StoreDbcontext>(options =>
                 options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefultConnections")));

            webApplicationBuilder.Services.AddSingleton<IConnectionMultiplexer>((options) => 
            {
                return ConnectionMultiplexer.Connect(webApplicationBuilder.Configuration.GetConnectionString("Redis"));
            });

            webApplicationBuilder.Services.AddDbContext<IdentityStoreDbContext>(options =>
               options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("Identity")));
            webApplicationBuilder.Services.AddCors(config => 
            {
                config.AddPolicy("Policy01", p => 
                {
                    p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            webApplicationBuilder.Services.AddIdentityServices(webApplicationBuilder.Configuration);

            webApplicationBuilder.Services.AddAplicationServices();
            #endregion

            var app = webApplicationBuilder.Build();
            var Scope = app.Services.CreateScope();
            var Services =  Scope.ServiceProvider;
            var dbcontex = Services.GetRequiredService<StoreDbcontext>();
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            var IdentityDbcontxt = Services.GetRequiredService<IdentityStoreDbContext>();
            var UserManager = Services.GetRequiredService<UserManager<AppUser>>();

            try
            {
                 await  dbcontex.Database.MigrateAsync();
                 await IdentityDbcontxt.Database.MigrateAsync();
                 await   StoreDbcontextSeeding.DataSeedingAsync(dbcontex);
                 await   IdentityStoreDbContextSeeding.AddUserAsync(UserManager);

			}
            catch (Exception ex)
            {
                var log = LoggerFactory.CreateLogger<Program>();   
                log.LogError(string.Empty, ex.Message);
            }



            #region Configer Kestrel Middleware
            // Configure the HTTP request pipeline.

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

         

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("Policy01");

            app.UseAuthorization();
            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            app.Run();
        }
    }
}
