using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Domain.Entities
{
    public class Pedido
    {
       private readonly List<ItemPedido> _itens = new();

    public Guid Id { get; private set; }
    public Guid ClienteId { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public decimal ValorTotal => _itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    public IReadOnlyCollection<ItemPedido> Itens => _itens.AsReadOnly();

    private Pedido() { }

    public Pedido(Guid clienteId)
    {
        Id = Guid.NewGuid();
        ClienteId = clienteId;
        DataCriacao = DateTime.UtcNow;
    }

    public void AdicionarItem(Guid produtoId, int quantidade, decimal precoUnitario)
    {
        if (quantidade <= 0)
            throw new InvalidOperationException("Quantidade deve ser maior que zero.");

        _itens.Add(new ItemPedido(produtoId, quantidade, precoUnitario));
    } 
    }
}