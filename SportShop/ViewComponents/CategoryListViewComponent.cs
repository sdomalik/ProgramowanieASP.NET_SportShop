using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;
        public CategoryListViewComponent(ApplicationDbContext ctx)
        {
            this.db = ctx;
        }
        public async Task<IViewComponentResult> InvokeAsync(string category)
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        private Task<List<string>> GetCategoriesAsync()
        {
            return db.Products.Select(x => x.Category).Distinct().ToListAsync();
        }
    }
}
