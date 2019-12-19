using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{

    [Authorize]
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
            ViewBag.ActualPage = "Index";
            return View(_productRepository.Products);
        }

        public IActionResult Edit(int id)
        {
            
            return View(_productRepository.Products.FirstOrDefault(a => a.ProductId == id));
        }

        
        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.SaveProduct(product);
                TempData["ProductSaveSucces"] = "Product Saved";
                return RedirectToAction("Index", product);  
            }
            else
            {
                return View("Edit", product);
            }
        }

        public IActionResult Create()
        {
            return View("Edit", new Product());
        }

      
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product _productDeleted = _productRepository.DeleteProduct(id);

            TempData["ProductDeleteSucces"] = "Product Deleted";
            
            return RedirectToAction("Index");
        }

    }
}