﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.ServiceLayer.Contract
{
    public interface ICachadResponseService
    {
        Task CachadResponseAsync(string key, object value, TimeSpan time);

        Task<string?> GetCachadResponseAsync(string key);


    }
}
