using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzariaWebApi.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public PizzaModel Pizza { get; set; }
        public decimal ValorTotal { get; set; }
        public int TempoPreparo { get; set; }

        public PedidoModel(int id, PizzaModel pizza)
        {
            this.Id = id;
            this.Pizza = pizza;
            this.ValorTotal = this.Pizza.Tamanho.ValorFinanceiroAgregado + this.Pizza.Sabor.ValorFinanceiroAgregado;
            this.TempoPreparo = this.Pizza.Tamanho.TempoAgregado + this.Pizza.Sabor.TempoAgregado;
        }

        public void AplicaPersonalizacaoPizza(PizzaPersonalizacaoModel personalizacao)
        {
            this.Pizza.Personalizacoes.Add(personalizacao);
            this.ValorTotal += personalizacao.ValorFinanceiroAgregado;
            this.TempoPreparo += personalizacao.TempoAgregado;
        }
    }
}