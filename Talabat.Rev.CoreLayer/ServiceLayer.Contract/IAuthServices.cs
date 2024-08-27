using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites.IdentityData;

namespace Talabat.Rev.CoreLayer.ServiceLayer.Contract
{
    public interface IAuthServices
    {
        public Task<string> GenerateTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
