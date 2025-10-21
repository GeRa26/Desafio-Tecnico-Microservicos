using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Vendas.Application.DTOs;

namespace Vendas.Application.Queries.ObterPedidoPorId
{
    public record ObterPedidoPorIdQuery(Guid PedidoId) : IRequest<PedidoDto>;
}