using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzariaWebApi.Models
{
    public class PizzaAtributoAgregadoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorFinanceiroAgregado { get; set; }
        public int TempoAgregado { get; set; }
    }
}