﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop_Core;
using eShop_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Products.API.Repositories
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
