using PizzariaApp.Models.Enum;
using PizzariaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PizzariaWebApi.Controllers
{
    public class PedidosController : ApiController
    {
        //INICIANDO conjuntos de dados necessários em memória, irei retirar caso dê tempo de aplicar o uso do entity com o db
        private static List<PedidoModel> pedidos = new List<PedidoModel>();
        private static List<PizzaModel> pizzas = new List<PizzaModel>();
        private static List<PizzaTamanhoModel> pizzaTamanhos = new List<PizzaTamanhoModel>();
        private static List<PizzaSaborModel> pizzaSabores = new List<PizzaSaborModel>();
        private static List<PizzaPersonalizacaoModel> pizzaPersonalizacoes = new List<PizzaPersonalizacaoModel>();

        private List<PizzaTamanhoModel> getPizzaTamanhos()
        {
            if (pizzaTamanhos.Count <= 0)
            {
                pizzaTamanhos.Add(new PizzaTamanhoModel(1, (PizzaTamanhoEnum)1, "Pequena", 20.0m, 15));
                pizzaTamanhos.Add(new PizzaTamanhoModel(2, (PizzaTamanhoEnum)2, "Média", 30.0m, 20));
                pizzaTamanhos.Add(new PizzaTamanhoModel(3, (PizzaTamanhoEnum)3, "Grande", 40.0m, 25));
            }
            return pizzaTamanhos;
        }

        private List<PizzaSaborModel> getPizzaSabores()
        {
            if (pizzaSabores.Count <= 0)
            {
                pizzaSabores.Add(new PizzaSaborModel(1, (PizzaSaborEnum)1, "Calabresa", 0.0m, 0));
                pizzaSabores.Add(new PizzaSaborModel(2, (PizzaSaborEnum)2, "Marguerita", 0.0m, 0));
                pizzaSabores.Add(new PizzaSaborModel(3, (PizzaSaborEnum)3, "Portuguesa", 0.0m, 5));
            }
            return pizzaSabores;
        }

        private List<PizzaPersonalizacaoModel> getPizzaPersonalizacoes()
        {
            if (pizzaPersonalizacoes.Count <= 0)
            {
                pizzaPersonalizacoes.Add(new PizzaPersonalizacaoModel(1, (PizzaPersonalizacaoEnum)1, "Extra Bacon", 3.0m, 0));
                pizzaPersonalizacoes.Add(new PizzaPersonalizacaoModel(2, (PizzaPersonalizacaoEnum)2, "Sem Cebola", 0.0m, 0));
                pizzaPersonalizacoes.Add(new PizzaPersonalizacaoModel(3, (PizzaPersonalizacaoEnum)3, "Borda Recheada", 5.0m, 5));
            }
            return pizzaPersonalizacoes;
        }
        //FIM da inicialização dos conjuntos de dados necessários em memória, irei retirar caso dê tempo de aplicar o uso do entity com o db


        public PedidoModel Get(int id)
        {
            PedidoModel pedidoEncontrado = pedidos.Where(pedido => pedido.Id == id).Select(pedido => pedido).FirstOrDefault();
            return pedidoEncontrado;
        }

        [AcceptVerbs("GET")]
        [Route("api/ResumoPedido/{Id}")]
        public PedidoResumoModel GetResumoPedido(int id)
        {
            PedidoModel pedido = this.Get(id);
            PedidoResumoModel pedidoResumo = new PedidoResumoModel(pedido);
            return pedidoResumo;
        }

        public bool Post(PizzaTamanhoEnum tamanho_valor, PizzaSaborEnum sabor_valor)
        {
            int novo_id_pizza = 1;
            int novo_id_pedido = 1;
            if (pizzas.Count > 0)
            {
                novo_id_pizza = pizzas.Max(pizza => pizza.Id) + 1;
            }
            if (pedidos.Count > 0)
            {
                novo_id_pedido = pedidos.Max(pedido => pedido.Id) + 1;
            }

            PizzaTamanhoModel tamanho = this.getPizzaTamanhos()
                                            .Where(pizzaTamanho => pizzaTamanho.Tamanho == tamanho_valor)
                                            .Select(pizzaTamanho => pizzaTamanho).First();
            PizzaSaborModel sabor = this.getPizzaSabores()
                                        .Where(pizzaSabor => pizzaSabor.Sabor == sabor_valor)
                                        .Select(pizzaSabor => pizzaSabor).First();
            PizzaModel novaPizza = new PizzaModel(novo_id_pizza, tamanho, sabor);
            pizzas.Add(novaPizza);
            PedidoModel novoPedido = new PedidoModel(novo_id_pedido, novaPizza);
            pedidos.Add(novoPedido);
            return true;
        }

        public bool Put(int idPedido, PizzaPersonalizacaoEnum personalizacao_valor)
        {
            PedidoModel pedido = this.Get(idPedido);
            PizzaPersonalizacaoModel personalizacao = this.getPizzaPersonalizacoes()
                                                          .Where(pizzaPersonalizacao => pizzaPersonalizacao.Personalizacao == personalizacao_valor)
                                                          .Select(pizzaPersonalizacao => pizzaPersonalizacao).First();
            pedido.AplicaPersonalizacaoPizza(personalizacao);
            return true;
        }
    }
}