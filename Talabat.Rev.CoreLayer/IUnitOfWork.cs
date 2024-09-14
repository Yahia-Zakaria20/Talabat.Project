using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;

namespace Talabat.Rev.CoreLayer
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        //IGenericRepositry<Product> ProductRepo { get; set; }
        //IGenericRepositry<ProductBrand> ProductBrandRepo { get; set; }
        //IGenericRepositry<ProductCategory> ProductCategoryRepo { get; set; }
        //IGenericRepositry<Order> OrderRepo { get; set; }
        //IGenericRepositry<DeliveryMethod> DeliveryMethodRepo { get; set; }
        IWishListRepositry WishlistRepo { get; set; }

        public IGenericRepositry<TEntity> Repositry<TEntity>() where TEntity : BaseEntite;


        Task<int> CompleteAsync();
    }
}
