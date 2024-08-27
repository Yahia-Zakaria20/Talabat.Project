using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talabat.Rev.CoreLayer.Entites.IdentityData;

namespace Talabat.Rev.Extentions
{
    public static class EXtentions
    {


        public static async Task<AppUser> FindUserAddressByEmail(this UserManager<AppUser> usermanager, ClaimsPrincipal user) 
        {
            var Email =  user.FindFirstValue(ClaimTypes.Email);

            var AppUser = await usermanager.Users.Include(u => u.Address).SingleOrDefaultAsync(u => u.Email == Email);

            return AppUser;
        }
    }
}
