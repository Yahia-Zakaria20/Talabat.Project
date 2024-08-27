using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;

namespace Talabat.Rev.RepositoryLayer.Data
{
   public class UnitOfwork : IUnitOfWork
    {
        private readonly StoreDbcontext _storeDbcontext;

        //public IGenericRepositry<Product> ProductRepo { get ; set ; }
        //public IGenericRepositry<ProductBrand> ProductBrandRepo  { get ; set ; }
        //public IGenericRepositry<ProductCategory> ProductCategoryRepo  { get ; set ; }
        //public IGenericRepositry<Order> OrderRepo  { get ; set ; }
        //public IGenericRepositry<DeliveryMethod> DeliveryMethodRepo  { get ; set ; }
        //public IGenericRepositry<OrderItem> OrderItemRepo  { get ; set ; }

        private readonly Hashtable _Repos;
        public UnitOfwork(StoreDbcontext storeDbcontext)
        {
            _storeDbcontext = storeDbcontext;

            _Repos  =new  Hashtable();

            ///ProductBrandRepo = new GenericRepositry<ProductBrand>(_storeDbcontext);
            ///ProductRepo = new GenericRepositry<Product>(_storeDbcontext);
            ///ProductCategoryRepo = new GenericRepositry<ProductCategory>(_storeDbcontext);
            ///OrderRepo = new GenericRepositry<Order>(_storeDbcontext);
            ///OrderItemRepo = new GenericRepositry<OrderItem>(_storeDbcontext);
            ///DeliveryMethodRepo = new GenericRepositry<DeliveryMethod>(_storeDbcontext);


        }


        public IGenericRepositry<TEntity> Repositry<TEntity>() where TEntity : BaseEntite
        {
           var key = typeof(TEntity).Name;

            if (!_Repos.ContainsKey(key))
            {
                var repo = new GenericRepositry<TEntity>(_storeDbcontext);
                 _Repos.Add(key,repo);
            }

            
            return _Repos[key] as IGenericRepositry<TEntity>;
        }
        public async Task<int> CompleteAsync()
        {
          return await   _storeDbcontext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
          await  _storeDbcontext.DisposeAsync();
        }

      
    }
}
