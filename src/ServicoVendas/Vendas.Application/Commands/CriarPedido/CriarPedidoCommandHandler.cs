using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Domain.Entities;
using Vendas.Domain.Repositories;
using Vendas.Infrastructure.Messaging;
using Vendas.Application.Events;



namespace Vendas.Application.Commands.CriarPedido
{
    public class CriarPedidoCommandHandler : IRequestHandler<CriarPedidoCommand, Guid>
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IEventPublisher _eventPublisher;

    public CriarPedidoCommandHandler(IPedidoRepository pedidoRepository, IEventPublisher eventPublisher)
    {
        _pedidoRepository = pedidoRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task<Guid> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
    {
        // Cria a entidade de domínio
        var pedido = new Pedido(request.ClienteId);

        foreach (var item in request.Itens)
        {
            pedido.AdicionarItem(item.ProdutoId, item.Quantidade, item.PrecoUnitario);
        }

        // Persiste via repositório (não sabe de EF Core)
        await _pedidoRepository.AdicionarAsync(pedido);

        // Publica um evento de domínio
        await _eventPublisher.PublishAsync(new PedidoCriadoEvent(pedido.Id, pedido.ClienteId));

        return pedido.Id;
    }
}
}