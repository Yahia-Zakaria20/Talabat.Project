using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;
using Talabat.Rev.CoreLayer.Entites.OrderAggregate;

namespace Talabat.Rev.RepositoryLayer.Data
{
	public static class StoreDbcontextSeeding
	{
		public static async Task DataSeedingAsync(StoreDbcontext dbcontext) 
		{

			if (dbcontext.ProductBrands.Count() == 0)
			{
				// productBrand 
				var jsonfile = File.ReadAllText("../Talabat.Rev.RepositoryLayer/Data/JsonFiles/brands.json");

				var Products = JsonSerializer.Deserialize<IEnumerable<ProductBrand>>(jsonfile);

				if (Products.Count() > 0)
				{
					foreach (var product in Products)
					{
						dbcontext.ProductBrands.Add(product);
					}

					await dbcontext.SaveChangesAsync();
				} 
			}

			if (dbcontext.ProductCategories.Count() == 0)
			{
				// productBrand 
				var jsonfile = File.ReadAllText("../Talabat.Rev.RepositoryLayer/Data/JsonFiles/categories.json");

				var Products = JsonSerializer.Deserialize<IEnumerable<ProductCategory>>(jsonfile);

				if (Products.Count() > 0)
				{
					//Products = Products.Select(p => new ProductCategory { Name = p.Name });

					foreach (var product in Products)
					{
						dbcontext.ProductCategories.Add(product);
					}

					await dbcontext.SaveChangesAsync();
				}
			}

			if (dbcontext.Products.Count() == 0)
			{
				// productBrand 
				var jsonfile = File.ReadAllText("../Talabat.Rev.RepositoryLayer/Data/JsonFiles/products.json");

				var Products = JsonSerializer.Deserialize<IEnumerable<Product>>(jsonfile);

				if (Products.Count() > 0)
				{
					foreach (var product in Products)
					{
						dbcontext.Products.Add(product);
					}

					await dbcontext.SaveChangesAsync();
				}
			}

			if (dbcontext.DeliveryMethods.Count() == 0) 
			{
                var jsonfile = File.ReadAllText("../Talabat.Rev.RepositoryLayer/Data/JsonFiles/delivery.json");

                var deliverymethods = JsonSerializer.Deserialize<IEnumerable<DeliveryMethod>>(jsonfile);

                if (deliverymethods.Count() > 0)
                {
                    foreach (var deliverymethod in deliverymethods)
                    {
                        dbcontext.DeliveryMethods.Add(deliverymethod);
                    }

                    await dbcontext.SaveChangesAsync();
                }
            }

		}
	}
}
