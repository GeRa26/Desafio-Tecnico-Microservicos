using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Application.DTOs;
using Vendas.Domain.Repositories;

namespace Vendas.Application.Queries.ObterPedidoPorId
{
    public class ObterPedidoPorIdQueryHandler : IRequestHandler<ObterPedidoPorIdQuery, PedidoDto>
{
    private readonly IPedidoRepository _pedidoRepository;

    public ObterPedidoPorIdQueryHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<PedidoDto> Handle(ObterPedidoPorIdQuery request, CancellationToken cancellationToken)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(request.PedidoId);

        if (pedido == null)
            throw new Exception("Pedido não encontrado");

        return new PedidoDto
        {
            Id = pedido.Id,
            ClienteId = pedido.ClienteId,
            DataCriacao = pedido.DataCriacao,
            Itens = pedido.Itens.Select(i => new ItemPedidoDto
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade,
                PrecoUnitario = i.PrecoUnitario
            }).ToList()
        };
    }
}
}