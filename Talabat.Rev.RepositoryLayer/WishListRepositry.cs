using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;
using Talabat.Rev.CoreLayer.Specifications;
using Talabat.Rev.RepositoryLayer.Data;

namespace Talabat.Rev.RepositoryLayer
{
  public class WishListRepositry : GenericRepositry<WishlistItem>, IWishListRepositry
    {
        private readonly StoreDbcontext _dbcontext;

        public WishListRepositry(StoreDbcontext dbcontext)
            :base(dbcontext) 
        {
            _dbcontext = dbcontext;
        }

        public async Task<IReadOnlyList<Product>?> GetAllProductForUserByEmailAsync(string email)
        {
         var product =  await _dbcontext.WishlistItems.Where(w => w.UserEmail == email)
                                                      .Include(w => w.Product)
                                                      .ThenInclude(p => p.ProductBrand)
                                                      .Include(w => w.Product)
                                                      .ThenInclude(p => p.ProductCategory)
                                                      .Select(w => w.Product)
                                                      .ToListAsync();
               if(product is null) 
                return null;

            return product;
                
        }

        public async Task<WishlistItem?> GetWishlistobjAsync(string email, int productid) 
        {
            var result =await  _dbcontext.WishlistItems.Where(w => w.UserEmail == email && w.ProductId == productid)
                                                       .FirstOrDefaultAsync();
            if (result is null) 
                return null;
            return result;
        }
    }
}
