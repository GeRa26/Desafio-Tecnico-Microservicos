using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;

namespace Vendas.Infrastructure.Persistence
{
    public class VendasDbContext : DbContext
{
    public VendasDbContext(DbContextOptions<VendasDbContext> options)
        : base(options) { }

    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapeamento do agregado Pedido → Itens
        modelBuilder.Entity<Pedido>(builder =>
        {
            builder.HasKey(p => p.Id);

            builder.OwnsMany(p => p.Itens, i =>
            {
                i.WithOwner().HasForeignKey("PedidoId");
                i.Property<Guid>("Id");
                i.HasKey("Id");
                i.Property(p => p.PrecoUnitario).HasColumnType("decimal(18,2)");
            });
        });
    }
}
}