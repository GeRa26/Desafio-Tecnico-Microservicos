using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Domain.Entities
{
    public class ItemPedido
    {
         public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }

    private ItemPedido() { }

    public ItemPedido(Guid produtoId, int quantidade, decimal precoUnitario)
    {
        ProdutoId = produtoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }
    }
}