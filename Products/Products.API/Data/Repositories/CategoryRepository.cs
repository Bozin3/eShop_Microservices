using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.API.Models;

namespace eShop_Backend.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly eShopContext eShopContext;
        public CategoryRepository(eShopContext eShopContext)
        {
            this.eShopContext = eShopContext;
        }

        public Task<List<Category>> GetAllCategories()
        {
            return eShopContext.Categories.ToListAsync();
        }

        public Task<Category> GetCategoryById(int id)
        {
            return eShopContext.Categories.Where(c => c.Id == id)
                       .Include(c => c.Products)
                       .FirstOrDefaultAsync();
        }
    }
}
