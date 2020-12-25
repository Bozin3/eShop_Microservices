using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.API.Models;

namespace eShop_Backend.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly eShopContext context;

        public ProductsRepository(eShopContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await context.Products.FindAsync(productId);
        }

        public async Task<List<Product>> GetProducts(int? categoryId, int startValue, int limit)
        {
            if (categoryId.HasValue)
            {
                return await context.Products.Where(p => p.CatId == categoryId)
               .Skip(startValue).Take(limit).ToListAsync();
            }
            
            return await context.Products.Skip(startValue).Take(limit).ToListAsync();
        }

    }
}
