using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        public AdminController(IProductRepository productRepository, IManufacturerRepository manufacturerRepository)
        {
            this._productRepository = productRepository;
            this._manufacturerRepository = manufacturerRepository;
        }
        public IActionResult Index()
        {
            return View(_productRepository.Products);
        }

        public IActionResult Edit(int id)
        {
            return View(_productRepository.Products.FirstOrDefault(a => a.ProductId == id));
        }
        public IActionResult Create()
        {
            return View("Edit", new Product());
        }
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Save(product);
            }

            return RedirectToAction("Index", product);
        }
    }
}