using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Vendedor
    {
        public int id { get; set; }
        public String nome { get; set; }
        public string email { get; set; }
        public DateTime dataAnivesario { get; set; }
        public double salarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroVenda> Venda { get; set; } = new List<RegistroVenda>();

        public Vendedor() 
        { 
        }

        public Vendedor(int id, string nome, string email, DateTime dataAnivesario, double salarioBase, Departamento departamento)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.dataAnivesario = dataAnivesario;
            this.salarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVenda(RegistroVenda sr)
        {
            Venda.Add(sr);
        }
        public void RemoveVenda(RegistroVenda sr)
        {
            Venda.Remove(sr);
        }

        public double totalVendas(DateTime inicio, DateTime fim)
        {
            return Venda.Where(sr => sr.Data >= inicio && sr.Data <= fim).Sum(sr => sr.valor);            
        }

    }
}
