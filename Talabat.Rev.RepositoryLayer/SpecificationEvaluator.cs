using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Specifications;

namespace Talabat.Rev.RepositoryLayer
{
    public static class SpecificationEvaluator<T>where T : BaseEntite
    {

        public static IQueryable<T> GetQuary(IQueryable<T> Dbset, ISpecifications<T> specifications) 
        {

            var Quary = Dbset;


            if (specifications.Criteria is not null)
                Quary = Quary.Where(specifications.Criteria);

              if(specifications.OrderBy is not null)
                Quary = Quary.OrderBy(specifications.OrderBy);
            else if(specifications.OrderByDesc is not null)
                Quary = Quary.OrderByDescending(specifications.OrderByDesc);

            if (specifications.ispagenation)
                Quary = Quary.Skip(specifications.skip).Take(specifications.Take);



            Quary = specifications.Includs.Aggregate(Quary, (CurrentQuary, IncludExprssion) => CurrentQuary.Include(IncludExprssion));

            return Quary;
        }
    }
}
