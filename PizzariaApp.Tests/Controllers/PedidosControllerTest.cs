using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzariaApp.Models.Enum;
using PizzariaWebApi.Controllers;
using PizzariaWebApi.Models;

namespace PrjPizzaria.Tests.Controllers
{
    [TestClass]
    public class PedidosControllerTest
    {
        [TestMethod]
        public void Post()
        {
            PedidosController pedidosController = new PedidosController();
            bool resultado = pedidosController.Post((PizzaTamanhoEnum)2, (PizzaSaborEnum)1);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Get()
        {
            PedidosController pedidosController = new PedidosController();
            PedidoModel pedidoEncontrado = pedidosController.Get(1);

            Assert.IsNotNull(pedidoEncontrado);
            Assert.AreNotEqual(pedidoEncontrado.Id, 0);
            Assert.AreEqual(PizzaTamanhoEnum.media, pedidoEncontrado.Pizza.Tamanho.Tamanho);
            Assert.AreEqual(PizzaSaborEnum.calabresa, pedidoEncontrado.Pizza.Sabor.Sabor);
        }

        [TestMethod]
        public void Put()
        {
            PedidosController pedidosController = new PedidosController();
            bool resultado = pedidosController.Put(1, (PizzaPersonalizacaoEnum)1);

            Assert.IsTrue(resultado);
            PedidoModel pedidoEncontrado = pedidosController.Get(1);

            Assert.IsNotNull(pedidoEncontrado);
            Assert.AreNotEqual(pedidoEncontrado.Id, 0);
            Assert.AreEqual(PizzaTamanhoEnum.media, pedidoEncontrado.Pizza.Tamanho.Tamanho);
            Assert.AreEqual(PizzaSaborEnum.calabresa, pedidoEncontrado.Pizza.Sabor.Sabor);
            Assert.AreEqual(PizzaPersonalizacaoEnum.extraBacon, pedidoEncontrado.Pizza.Personalizacoes[0].Personalizacao);
        }

        [TestMethod]
        public void GetResumoPedido()
        {
            PedidosController pedidosController = new PedidosController();
            PedidoResumoModel resumoPedido = pedidosController.GetResumoPedido(1);

            Assert.IsNotNull(resumoPedido);
            Assert.AreEqual(resumoPedido.SaborPizza, "Calabresa");
            Assert.AreEqual(resumoPedido.TamanhoPizza, "Média");
            Assert.AreEqual(resumoPedido.PrecoPizza, 30.0m);
            Assert.AreEqual(resumoPedido.PersonalizacoesPizza[0].Personalizacao, "Extra Bacon");
            Assert.AreEqual(resumoPedido.PersonalizacoesPizza[0].Preco, 3.0m);
            Assert.AreEqual(resumoPedido.TotalPedido, 33.0m);
            Assert.AreEqual(resumoPedido.TempoPreparo, "20 minutos");
        }
    }
}
