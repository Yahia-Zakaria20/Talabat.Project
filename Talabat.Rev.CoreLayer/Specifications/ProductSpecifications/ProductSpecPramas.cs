using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Specifications.ProductSpecifications
{
    public class ProductSpecPramas
    {

        public string? sorting { get; set; }

        public int? brandid { get; set; }

        public int? catogaryid { get; set; }

        private string? name;

        public string? Name 
        {
            get { return name;}
            set { name = value.ToUpper(); }
        }


        public const int MaxPagesize = 10;


        private int pagesize;

        
        public int PageSize
        {
            get { return pagesize == 0 ? 5 : pagesize; }
            set { pagesize = value > MaxPagesize ? MaxPagesize : value ; }

        }

        public int pageindex { get; set; } = 1;
    }
}
