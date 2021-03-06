﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Vendedor
    {
        public int id { get; set; }

        [Display (Name = "Nome")]
        [Required(ErrorMessage = "O {0} é o obrigatorio")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve ter no minimo três letras e no maximo 60")]
        public String nome { get; set; }

        [Required(ErrorMessage = "O {0} é o obrigatorio")]
        [Display(Name = "e-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "O {0} é o obrigatorio")]
        [Display(Name = "Data Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dataAnivesario { get; set; }

        [Required(ErrorMessage = "O {0} é o obrigatorio")]
        [Display(Name = "Salário Base")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.00, 10000.00, ErrorMessage = "{0} deve ser no minimo {1} e no maximo {2}")]
        public double salarioBase { get; set; }

        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
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
