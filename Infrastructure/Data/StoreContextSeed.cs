using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, 
            ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/SeedData/brands.json");

                    var brands = JsonSerializer
                        .Deserialize<List<ProductBrand>>(brandsData);

                    await context.ProductBrands.AddRangeAsync(brands);
                    await context.SaveChangesAsync();

                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/SeedData/types.json");

                    var types = JsonSerializer
                        .Deserialize<List<ProductType>>(typesData);

                    await context.ProductTypes.AddRangeAsync(types);
                    await context.SaveChangesAsync();

                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/SeedData/products.json");

                    var products = JsonSerializer
                        .Deserialize<List<Product>>(productsData);

                    await context.Products.AddRangeAsync(products);
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message); 
            }

        }
    }
}
