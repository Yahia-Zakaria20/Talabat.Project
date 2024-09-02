using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.ServiceLayer.Contract
{
    public interface ICachadResponseService
    {
        Task CachadResponse(string key, object value, TimeSpan time);

        Task<string?> GetCachadResponse(string key);


    }
}
