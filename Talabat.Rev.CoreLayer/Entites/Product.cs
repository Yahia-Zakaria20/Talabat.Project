using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites
{
    public class Product : BaseEntite
	{
        

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl {  get; set; }
        
        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int CategoryId { get; set; }

       public ProductCategory ProductCategory { get; set; }


    }
}
