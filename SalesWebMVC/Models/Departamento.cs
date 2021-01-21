using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string None { get; set; }
        public ICollection<Vendedor> vendedores { get; set; } = new List<Vendedor>();

        public Departamento() 
        { 
        }

        public Departamento(int id, string none)
        {
            Id = id;
            None = none;
        }

        public void AddVendedor(Vendedor regvendedor)
        {
            vendedores.Add(regvendedor);
        }

        public double TotalVendas(DateTime inicial, DateTime Final)
        {
            return vendedores.Sum(regvendedor => regvendedor.totalVendas(inicial, Final));            
        }
    }
}
