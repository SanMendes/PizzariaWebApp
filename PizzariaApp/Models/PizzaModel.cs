using PizzariaApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzariaWebApi.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        public PizzaTamanhoModel Tamanho { get; set; }
        public PizzaSaborModel Sabor { get; set; }
        public List<PizzaPersonalizacaoModel> Personalizacoes { get; set; }

        public PizzaModel(int id, PizzaTamanhoModel tamanho, PizzaSaborModel sabor)
        {
            this.Id = id;
            this.Tamanho = tamanho;
            this.Sabor = sabor;
            this.Personalizacoes = new List<PizzaPersonalizacaoModel>();
        }

        public decimal GetPrecoPizza()
        {
            return this.Tamanho.ValorFinanceiroAgregado + this.Sabor.ValorFinanceiroAgregado;
        }
    }
}