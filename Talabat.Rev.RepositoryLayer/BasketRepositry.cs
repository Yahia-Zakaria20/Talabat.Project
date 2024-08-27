using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;

namespace Talabat.Rev.RepositoryLayer
{
    public class BasketRepositry : IBasketRepositry
    {
        private readonly IDatabase _database;
        public BasketRepositry(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
          return  await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            var basket =  await _database.StringGetAsync(id);

            if (basket.IsNullOrEmpty)
                return null;
             
            return JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var CustomerBasket = await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
            if (!CustomerBasket)
                return null;

            return await GetBasketAsync(basket.Id);
            
        }
    }
}
