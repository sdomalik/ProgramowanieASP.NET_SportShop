﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerRepository repository;
        public ManufacturerController(IManufacturerRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult List() {

            ViewBag.ActualPage = "ManufacturerList";
            return View(repository.Manufacturers);
        } 

    }
}