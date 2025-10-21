using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Repositories;
using Vendas.Infrastructure.Persistence;

namespace Vendas.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
{
    private readonly VendasDbContext _context;

    public PedidoRepository(VendasDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task<Pedido?> ObterPorIdAsync(Guid id)
        => await _context.Pedidos
            .Include(p => p.Itens)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Pedido>> ListarAsync()
        => await _context.Pedidos
            .Include(p => p.Itens)
            .ToListAsync();
}
}