using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    [Route("api/[controller]")]
    public class ProductApiController : Controller
    {
        private readonly IProductRepository repository;
        public ProductApiController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        /// <summary>
        /// View list of all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Product> Get() => repository.Products;

        /// <summary>
        /// View single product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Product Get(int id) => repository.Products.FirstOrDefault(a => a.ProductId == id);


        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public Product Post(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category
                });
            }

            return product;
        }

   /*     /// <summary>
        /// Change data of products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Product Put(int id)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == id);

            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
            }


            return new Product { ProductId = product.ProductId };
        }*/

        /// <summary>
        /// Deletes product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Product Delete(int id)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == id);
            if (ModelState.IsValid)
            {
                repository.DeleteProduct(id);
            }

            return product;
        }


    }

    
}