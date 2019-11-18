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

        public void SaveProduct(Product product)
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

        public Product DeleteProduct(int id)
        {
            Product product = ctx.Products.FirstOrDefault(a => a.ProductId == id);

            if (product != null)
            {
                ctx.Products.Remove(product);
                ctx.SaveChanges();
            }
            return product;
        }

        public IQueryable<Product> Products => ctx.Products;

    }
}
