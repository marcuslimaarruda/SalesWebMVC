﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Data;

namespace SalesWebMVC.Services
{
    public class VendedorService
    {
        private readonly SalesWebMVCContext _context;

        public VendedorService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Vendedor> findAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            //Gambiarra para não dar erro quanto não faz a tela de seleção do departamento.
            //obj.Departamento = _context.Departamento.First();

            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
