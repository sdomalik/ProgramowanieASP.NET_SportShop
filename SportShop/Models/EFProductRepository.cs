using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext ctx;
        public IQueryable<Product> Products => ctx.Products;
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
            else if (product.ProductId != 0)
            {
                Product productToChange = ctx.Products.SingleOrDefault(a => a.ProductId == product.ProductId);
                if (productToChange != null)
                {
                    productToChange.Name = product.Name;
                    productToChange.Description = product.Description;
                    productToChange.Category = product.Category;
                    productToChange.Price = product.Price;
                }
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


    }
}
