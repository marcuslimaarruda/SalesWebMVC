using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly SalesWebMVCContext _context;

        public DepartamentoService(SalesWebMVCContext context)
        {
            _context = context;
        }

        // Esta operação faz uma busca na base de dados de forma sincrona.
        // a aplicação aguarda o retorno. Isso pode ser muito lento.
        public List<Departamento> xFindAll() // Botei esse x só para dar erro e facilitar a substituição.
        {
            return _context.Departamento.OrderBy(x => x.None).ToList();
        }

        // Esta operação faz uma busca na base de dados de forma assincrona.
        // a aplicação não aguarda o retorno e continua disponivel. 
        // Isso melhora aperformance em consultas grandes.
        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.None).ToListAsync();
        }
    }
}
