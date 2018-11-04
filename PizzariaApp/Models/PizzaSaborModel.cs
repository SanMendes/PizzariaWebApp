using PizzariaApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzariaWebApi.Models
{
    public class PizzaSaborModel : PizzaAtributoAgregadoModel
    {
        public int Id { get; set; }
        public PizzaSaborEnum Sabor { get; set; }

        public PizzaSaborModel(int id, PizzaSaborEnum sabor, string descricao, decimal valor, int tempo)
        {
            this.Id = id;
            this.Sabor = sabor;
            this.Descricao = descricao;
            this.ValorFinanceiroAgregado = valor;
            this.TempoAgregado = tempo;
        }
    }
}