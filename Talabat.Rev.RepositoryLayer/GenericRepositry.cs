using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.RepositoryLayer.Contract;
using Talabat.Rev.RepositoryLayer.Data;
using Microsoft.EntityFrameworkCore;
using Talabat.Rev.CoreLayer.Specifications;
namespace Talabat.Rev.RepositoryLayer
{
	public class GenericRepositry<T> : IGenericRepositry<T> where T : BaseEntite
	{
		private readonly StoreDbcontext _dbcontext;
        public GenericRepositry(StoreDbcontext dbcontext)
        {
			_dbcontext = dbcontext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
		{	
		  return await _dbcontext.Set<T>().AsNoTracking().ToListAsync();
        }

		public async Task<T?> GetByIdAsync(int id)
		{
            return await _dbcontext.Set<T>().FindAsync(id);
		}

        public async Task<IReadOnlyList<T>> GetAllAsyncWithSpec(ISpecifications<T> specifications)
        {
            return await GenerateQuaryAsync(specifications).AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsyncWithSpec(ISpecifications<T> specifications)
        {
            return await GenerateQuaryAsync(specifications).FirstOrDefaultAsync();
        }

        private IQueryable<T> GenerateQuaryAsync(ISpecifications<T> specifications)
        {
            return SpecificationEvaluator<T>.GetQuary(_dbcontext.Set<T>(), specifications);
        }

        public async Task<int> GetCountAsync(ISpecifications<T> specifications)
        {
          return  await GenerateQuaryAsync(specifications).CountAsync();
        }

        public async Task AddAsync(T entity)
        =>  await  _dbcontext.Set<T>().AddAsync(entity);
        

        public void Update(T entity)
           => _dbcontext.Set<T>().Update(entity);   
        

        public void Delet(T entity)
          =>   _dbcontext.Set<T>().Remove(entity);
        

        #region Test
        ////public async Task<IReadOnlyList<T>> GetAllAsync()
        ////{
        ////    if (typeof(T) == typeof(Product))
        ////        return await _dbcontext.Products.OrderBy(p => p.)

        ////  return await _dbcontext.Set<T>().ToListAsync();
        ////} 
        #endregion
    }
}
