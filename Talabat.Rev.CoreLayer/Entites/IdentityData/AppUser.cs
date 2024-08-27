﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites.IdentityData
{
    public class AppUser : IdentityUser
    {
      public string DisplayName { get; set; }
         
        public Address Address { get; set; }

    }
}
