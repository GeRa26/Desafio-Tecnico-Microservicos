using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Vendas.Application.Commands.CriarPedido
{
    public record CriarPedidoCommand(
    Guid ClienteId,
    List<ItemPedidoCommand> Itens
) : IRequest<Guid>; // Retorna o Id do pedido criado

public record ItemPedidoCommand(Guid ProdutoId, int Quantidade, decimal PrecoUnitario);
}