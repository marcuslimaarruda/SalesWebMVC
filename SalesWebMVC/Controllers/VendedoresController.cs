﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _sellerService;

        public VendedoresController(VendedorService vendedorService)
        {
            _sellerService = vendedorService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.findAll();

            return View(list);
        }
    }
}