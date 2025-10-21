using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Application.DTOs
{
   public class PedidoDto
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public DateTime DataCriacao { get; set; }
    public List<ItemPedidoDto> Itens { get; set; } = [];
}

public class ItemPedidoDto
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
}
}