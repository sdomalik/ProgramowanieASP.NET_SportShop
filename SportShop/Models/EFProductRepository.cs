using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext ctx;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

       public void DeleteProduct(int id)
        {
            ctx.Remove(ctx.Products.FirstOrDefault(a => a.ProductId == id));
            ctx.SaveChanges();
        }

        public void Save(Product product)
        {
            if (product.ProductId == 0)
            {
                ctx.Products.Add(product);
            }
            else
            {
                ctx.Update(product);
            }
            ctx.SaveChanges();
        }
        public IQueryable<Product> Products => ctx.Products;

    }
}
