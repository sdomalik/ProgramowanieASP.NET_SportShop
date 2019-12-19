using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public ViewResult List(string category)
        {
            ViewBag.ActualPage = "ProductList";
            ViewBag.ActualCategory = category;
            return View(repository.Products.Where(a => a.Category == category));
        }

        [HttpGet]
        public ViewResult ProductById(int id)
        {
            return View(repository.Products.SingleOrDefault(p => p.ProductId == id));
        }

    }
}