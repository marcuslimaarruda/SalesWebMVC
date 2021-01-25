using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Excepptions;

namespace SalesWebMVC.Services
{
    public class VendedorService
    {
        private readonly SalesWebMVCContext _context;

        public VendedorService(SalesWebMVCContext context)
        {
            _context = context;
        }

        // Esta operação faz uma busca na base de dados de forma sincrona.
        // a aplicação aguarda o retorno. Isso pode ser muito lento.
        public List<Vendedor> xfindAll() // Botei esse x só para dar erro e facilitar a substituição.
        {
            return _context.Vendedor.ToList();
        }

        // Esta operação faz uma busca na base de dados de forma assincrona.
        // a aplicação não aguarda o retorno e continua disponivel. 
        // Isso melhora aperformance em consultas grandes.
        public async Task<List<Vendedor>> findAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        //Insert sincrono.
        public void xInsert(Vendedor obj)
        {
            //Gambiarra para não dar erro quanto não faz a tela de seleção do departamento.
            //obj.Departamento = _context.Departamento.First();

            _context.Add(obj);
            _context.SaveChanges();
        }

        //Insert asincrono.
        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);
            // Esse éo comando que vai acessar a base e vira assincrono.
            await _context.SaveChangesAsync();
        }

        // Busca sincrona
        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.id == id);
        }

        // Busca Assincrona
        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.id == id);
        }

        // Remove sincrono
        public void xRemove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        // Remove assincrono
        public async Task RemoveAsync(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Update sincrono
        public async void xUpdate(Vendedor obj)
        {
            bool ExisteAlgum = await _context.Vendedor.AnyAsync(x => x.id == obj.id);

            if (!ExisteAlgum)
            {
                throw new NotFoundException("Vendedor não foi localizado na base de dados!");
            }
            // Executa a atuaização.
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        // Update assincrono
        public async Task UpdateAsync(Vendedor obj)
        {
            if (!_context.Vendedor.Any(x => x.id == obj.id))
            {
                throw new NotFoundException("Vendedor não foi localizado na base de dados!");
            }
            // Executa a atuaização.
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
