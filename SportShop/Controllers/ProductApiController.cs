using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class ProductApiController : Controller
    {
        private readonly IProductRepository repository;
        public ProductApiController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*[HttpGet]
        public ActionResult List(string category)
        {
            return
        }*/


    }
}