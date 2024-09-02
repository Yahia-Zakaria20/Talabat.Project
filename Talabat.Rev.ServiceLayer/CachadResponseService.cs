using Microsoft.AspNetCore.Components.Routing;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.ServiceLayer.Contract;

namespace Talabat.Rev.ServiceLayer
{
    public class CachadResponseService : ICachadResponseService
    {
        private readonly IDatabase _dataBase;

        public CachadResponseService(IConnectionMultiplexer connection)
        {
            _dataBase =connection.GetDatabase();
        }
        public async Task CachadResponse(string key, object value, TimeSpan time)
        {
            if (value is null)
                return ;

           var SerializeOptions = new JsonSerializerOptions() { PropertyNamingPolicy =  JsonNamingPolicy.CamelCase };
            var SerializeResponse = JsonSerializer.Serialize(value, SerializeOptions);
           await _dataBase.StringSetAsync(key, SerializeResponse, time);
        }

        public async Task<string?> GetCachadResponse(string key)
        {
          var CachadResponse = await   _dataBase.StringGetAsync(key);
            if(CachadResponse.IsNullOrEmpty)
                return null;
          
            return CachadResponse;
        }
    }
}
