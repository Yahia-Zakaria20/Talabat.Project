using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace Talabat.Rev.CoreLayer.RepositoryLayer.Contract
{
    public interface IBasketRepositry
    {

        public Task<CustomerBasket?> GetBasketAsync(string id);

        public Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);

        public Task<bool> DeleteBasketAsync(string id);
    }
}
