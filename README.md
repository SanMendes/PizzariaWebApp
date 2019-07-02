# PizzariaApp
Exemplo de uma Web API Rest, para fins didáticos, com métodos para inserir pedido de pizza e consultar o resumo do pedido


# API Rest

Cria um novo pedido de pizza definindo o tamanho e o sabor
Método POST
-  [host_da_aplicacao]/api/Pedidos?tamanho_valor=[numero_referente]&sabor_valor=[numero_referente]

Altera um pedido de pizza para adicionar personalização na pizza
Método PUT
-  [host_da_aplicacao]/api/Pedidos?idPedido=[id]&personalizacao_valor=[numero_referente]

Busca todos os dados do pedido sem nenhum tratamento
Método GET
- [host_da_aplicacao]/api/Pedidos/[id]

Método GET
Busca o resumo do pedido para apresentação ao cliente
- [host_da_aplicacao]/api/ResumoPedido/[id]
