using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services.Excepptions;
using System.Diagnostics;

namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _sellerService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _sellerService = vendedorService;
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.findAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Novo()
        {
            var departamentos = await _departamentoService.FindAllAsync();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

 
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Novo(Vendedor vendedor)
        {
            // Este if é para o caso da critica em javascript falhar 
            // ele fica em loop devolvendo o mesmo objeto
            if (!ModelState.IsValid)
            {
                var departamento = await _departamentoService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamento };
                return View(viewModel);
            }

            await _sellerService.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Informado um identificador nulo." });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não foi localizado." });
            }

            return View(obj);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Informado um identificador nulo." });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não foi localizado." });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Informado um identificador nulo." });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não foi localizado." });
            }

            List<Departamento> departamentos = await _departamentoService.FindAllAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            // Este if é para o caso da critica em javascript falhar 
            // ele fica em loop devolvendo o mesmo objeto
            if (!ModelState.IsValid)
            {
                var departamento = await _departamentoService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamento };
                return View(viewModel);
            }

            if (id != vendedor.id)
            {
                return RedirectToAction(nameof(Error), new { message = "Erro executando a solcitação." });
            }

            try
            {
                await _sellerService.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return RedirectToAction(nameof(Error), new { message = "Erro atualizando vendedor. O vendedor não foi localizado." });
            }
            catch (DbConcurrencyException)
            {
                return RedirectToAction(nameof(Error), new { message = "Erro atualizando vendedor. O banco de dados retornou um erro." });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Messsage = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
            
        }

    }
}
