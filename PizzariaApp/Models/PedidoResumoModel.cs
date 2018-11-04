using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzariaWebApi.Models
{
    public class PedidoResumoModel
    {
        public string TamanhoPizza { get; set; }
        public string SaborPizza { get; set; }
        public decimal PrecoPizza { get; set; }
        public List<PersonalizacaoResumoModel> PersonalizacoesPizza { get; set; }
        public decimal TotalPedido { get; set; }
        public string TempoPreparo { get; set; }

        public PedidoResumoModel(PedidoModel pedido)
        {
            this.TamanhoPizza = pedido.Pizza.Tamanho.Descricao;
            this.SaborPizza = pedido.Pizza.Sabor.Descricao;
            this.PrecoPizza = pedido.Pizza.GetPrecoPizza();

            this.PersonalizacoesPizza = new List<PersonalizacaoResumoModel>();
            foreach (PizzaPersonalizacaoModel personalizacao in pedido.Pizza.Personalizacoes)
            {
                PersonalizacaoResumoModel personalizacaoResumo = new PersonalizacaoResumoModel()
                {
                    Personalizacao = personalizacao.Descricao,
                    Preco = personalizacao.ValorFinanceiroAgregado
                };

                this.PersonalizacoesPizza.Add(personalizacaoResumo);
            }

            this.TotalPedido = pedido.ValorTotal;
            this.TempoPreparo = pedido.TempoPreparo.ToString() + " minutos";

        }
    }
}