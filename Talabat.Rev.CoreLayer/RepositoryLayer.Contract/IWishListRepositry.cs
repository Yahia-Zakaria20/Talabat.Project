using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace Talabat.Rev.CoreLayer.RepositoryLayer.Contract
{
    public interface IWishListRepositry:IGenericRepositry<WishlistItem>
    {
        public Task<IReadOnlyList<Product>?> GetAllProductForUserByEmailAsync(string email);
        Task<WishlistItem?> GetWishlistobjAsync(string email, int productid);
    }
}
