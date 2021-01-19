using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> List = new List<Departamento>();

            List.Add(new Departamento { id = 1, Nome = "Eletrônicos" });
            List.Add(new Departamento { id = 2, Nome = "Moda" });

            return View(List);
        }
    }
}
