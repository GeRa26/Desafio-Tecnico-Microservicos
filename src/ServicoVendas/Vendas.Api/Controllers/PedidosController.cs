using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using Vendas.Application.Commands.CriarPedido;
using Vendas.Application.Queries.ObterPedidoPorId;

namespace Vendas.Api.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PedidosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST /api/pedidos
    [HttpPost]
    public async Task<IActionResult> CriarPedido([FromBody] CriarPedidoCommand command)
    {
        var pedidoId = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterPorId), new { id = pedidoId }, new { id = pedidoId });
    }

    // GET /api/pedidos/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var pedido = await _mediator.Send(new ObterPedidoPorIdQuery(id));
        return pedido is not null ? Ok(pedido) : NotFound();
    }
}
}