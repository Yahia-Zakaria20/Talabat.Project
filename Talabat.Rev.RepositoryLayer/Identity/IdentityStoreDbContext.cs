using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites.IdentityData;

namespace Talabat.Rev.RepositoryLayer.Identity
{
    public class IdentityStoreDbContext:IdentityDbContext<AppUser>
    {
        public IdentityStoreDbContext(DbContextOptions<IdentityStoreDbContext> options):base(options)
        {
            
        }


      
    }
}
