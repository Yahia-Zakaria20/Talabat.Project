using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites.IdentityData;

namespace Talabat.Rev.RepositoryLayer.Identity
{
    public static class IdentityStoreDbContextSeeding
    {
        public static async Task AddUserAsync(UserManager<AppUser> userManager) 
        {
            if (userManager.Users.Count() == 0)
            {

                var UserSeed = new AppUser()
                {
                    UserName = "Ziko55",
                    PhoneNumber = "0101111002",
                    Email = "YahiaZakaria@gamil.com",
                    DisplayName = "YahiaZakaria",
                };

                await userManager.CreateAsync(UserSeed, "12345678910Yz!@"); 
            }
        }
    }
}
