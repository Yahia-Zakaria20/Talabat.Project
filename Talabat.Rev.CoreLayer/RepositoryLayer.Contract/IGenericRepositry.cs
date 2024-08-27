using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Specifications;

namespace Talabat.Rev.CoreLayer.RepositoryLayer.Contract
{
	public  interface IGenericRepositry<T> where T : BaseEntite
	{

		public Task<IReadOnlyList<T>> GetAllAsync();

		public Task<T?> GetByIdAsync(int id);

		public Task<T?> GetByIdAsyncWithSpec(ISpecifications<T> specifications);

		public Task<IReadOnlyList<T>> GetAllAsyncWithSpec(ISpecifications<T> specifications);

		public Task<int> GetCountAsync(ISpecifications<T> specifications);

		Task AddAsync(T entity);
		void Update (T entity);
	    void Delet(T entity);

    }
}
