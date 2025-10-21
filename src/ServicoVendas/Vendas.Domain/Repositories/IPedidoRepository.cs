using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Vendas.Domain.Entities;

namespace Vendas.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task AdicionarAsync(Pedido pedido);
        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Pedido>> ListarAsync();
    }
}