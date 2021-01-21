using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void seed()
        {
            if (_context.Departamento.Any() ||
                _context.RegistroVenda.Any() ||
                _context.Vendedor.Any())
            {
                return; // Banco de dados não esta vazio não vou iniciar a operação de prencher
            }

            // Inserindo registros em Departamento.
            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletrônicos");
            Departamento d3 = new Departamento(3, "Moda");
            Departamento d4 = new Departamento(4, "Livros");

            // Inserindo Vendedores.

            Vendedor v1 = new Vendedor(1, "Carlos Alberto", "carlos.alberto@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor v2 = new Vendedor(2, "Manoel Silva", "manoel.silva@gmail.com", new DateTime(1998, 4, 21), 2000.0, d2);
            Vendedor v3 = new Vendedor(3, "Mariana Alberta", "mariana.albertao@gmail.com", new DateTime(1998, 4, 21), 1500.0, d1);
            Vendedor v4 = new Vendedor(4, "Cecilia Amorim", "cecilia.amorim@gmail.com", new DateTime(1998, 4, 21), 3000.0, d4);
            Vendedor v5 = new Vendedor(5, "Luiz Inacio", "luiz.inacio@gmail.com", new DateTime(1998, 4, 21), 4050.0, d3);
            Vendedor v6 = new Vendedor(6, "Maria do Carmo", "maria.carmo@gmail.com", new DateTime(1998, 4, 21), 700.0, d2);

            RegistroVenda rv1 = new RegistroVenda(1, new DateTime(2021, 01, 01), 1000.0, StatusVenda.Vendido, v1);
            RegistroVenda rv2 = new RegistroVenda(2, new DateTime(2021, 01, 02), 2000.0, StatusVenda.Cancelado, v2);
            RegistroVenda rv3 = new RegistroVenda(3, new DateTime(2021, 01, 03), 3000.0, StatusVenda.Pendente, v3);
            RegistroVenda rv4 = new RegistroVenda(24, new DateTime(2021, 01, 04), 600.0, StatusVenda.Vendido, v4);
            RegistroVenda rv5 = new RegistroVenda(4, new DateTime(2021, 01, 01), 600.0, StatusVenda.Vendido, v5);
            RegistroVenda rv6 = new RegistroVenda(5, new DateTime(2021, 01, 01), 5000.0, StatusVenda.Vendido, v6);
            RegistroVenda rv7 = new RegistroVenda(6, new DateTime(2021, 01, 04), 500.0, StatusVenda.Vendido, v1);
            RegistroVenda rv8 = new RegistroVenda(7, new DateTime(2021, 01, 03), 400.0, StatusVenda.Pendente, v4);
            RegistroVenda rv9 = new RegistroVenda(8, new DateTime(2021, 01, 05), 1000.0, StatusVenda.Vendido, v5);
            RegistroVenda rv10 = new RegistroVenda(9, new DateTime(2021, 01, 10), 1500.0, StatusVenda.Vendido, v2);
            RegistroVenda rv11 = new RegistroVenda(10, new DateTime(2021, 01, 08), 1500.0, StatusVenda.Vendido, v3);
            RegistroVenda rv12 = new RegistroVenda(11, new DateTime(2021, 01, 05), 1700.0, StatusVenda.Vendido, v4);
            RegistroVenda rv13 = new RegistroVenda(12, new DateTime(2021, 01, 01), 1200.0, StatusVenda.Vendido, v5);
            RegistroVenda rv14 = new RegistroVenda(13, new DateTime(2021, 01, 07), 800.0, StatusVenda.Cancelado, v6);
            RegistroVenda rv15 = new RegistroVenda(14, new DateTime(2021, 01, 06), 1000.0, StatusVenda.Vendido, v4);
            RegistroVenda rv16 = new RegistroVenda(15, new DateTime(2021, 01, 09), 2000.0, StatusVenda.Vendido, v2);
            RegistroVenda rv17 = new RegistroVenda(16, new DateTime(2021, 01, 08), 4000.0, StatusVenda.Vendido, v1);
            RegistroVenda rv18 = new RegistroVenda(17, new DateTime(2021, 01, 08), 1000.0, StatusVenda.Vendido, v3);
            RegistroVenda rv19 = new RegistroVenda(18, new DateTime(2021, 01, 10), 4000.0, StatusVenda.Vendido, v1);
            RegistroVenda rv20 = new RegistroVenda(19, new DateTime(2021, 01, 05), 7000.0, StatusVenda.Cancelado, v6);
            RegistroVenda rv21 = new RegistroVenda(20, new DateTime(2021, 01, 02), 700.0, StatusVenda.Vendido, v3);
            RegistroVenda rv22 = new RegistroVenda(21, new DateTime(2021, 01, 04), 100.0, StatusVenda.Vendido, v4);
            RegistroVenda rv23 = new RegistroVenda(22, new DateTime(2021, 01, 01), 50.0, StatusVenda.Vendido, v4);
            RegistroVenda rv24 = new RegistroVenda(23, new DateTime(2021, 01, 06), 500.0, StatusVenda.Vendido, v1);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);
            _context.RegistroVenda.AddRange(rv1, rv2, rv3, rv4, rv5, rv6, rv7, rv8, rv9, rv10, rv11, rv12, rv13, rv14, rv15, rv16, rv17, rv18, rv19, rv20, rv21, rv22, rv23, rv24);

            _context.SaveChanges();
        }
    }
}
