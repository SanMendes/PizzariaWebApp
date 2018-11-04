using PizzariaApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzariaWebApi.Models
{
    public class PizzaTamanhoModel : PizzaAtributoAgregadoModel
    {
        public int Id { get; set; }
        public PizzaTamanhoEnum Tamanho { get; set; }

        public PizzaTamanhoModel(int id, PizzaTamanhoEnum tamanho, string descricao, decimal valor, int tempo)
        {
            this.Id = id;
            this.Tamanho = tamanho;
            this.Descricao = descricao;
            this.ValorFinanceiroAgregado = valor;
            this.TempoAgregado = tempo;
        }
    }
}