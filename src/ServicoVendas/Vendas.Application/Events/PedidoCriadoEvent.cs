using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Application.Events
{
   public record PedidoCriadoEvent(Guid PedidoId, Guid ClienteId);
}