using System;
using System.Collections.Generic;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class RegistroVenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double valor { get; set; }
        public StatusVenda status { get; set; }
        public Vendedor Vendedor { get; set; }
        
        public RegistroVenda()
        {
        }

        public RegistroVenda(int id, DateTime data, double valor, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            this.valor = valor;
            this.status = status;
            Vendedor = vendedor;
        }
    }


}
