using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace Talabat.Rev.CoreLayer.Specifications
{
    public interface ISpecifications<T>where T :BaseEntite
    {
        List<Expression<Func<T,object>>> Includs { get; set; }

        Expression<Func<T, bool>> Criteria { get; set; }

        Expression<Func<T, object>> OrderBy { get; set; }

        Expression<Func<T, object>> OrderByDesc { get; set; }

        bool ispagenation { get; set; }

       int Take { get; set; }

        int  skip { get; set; }
    }
}
