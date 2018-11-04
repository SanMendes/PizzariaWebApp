using PizzariaApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzariaWebApi.Models
{
    public class PizzaPersonalizacaoModel : PizzaAtributoAgregadoModel
    {
        public PizzaPersonalizacaoEnum Personalizacao { get; set; }

        public PizzaPersonalizacaoModel(int id, PizzaPersonalizacaoEnum personalizacao, string descricao, decimal valor, int tempo)
        {
            this.Id = id;
            this.Personalizacao = personalizacao;
            this.Descricao = descricao;
            this.ValorFinanceiroAgregado = valor;
            this.TempoAgregado = tempo;
        }
    }
}