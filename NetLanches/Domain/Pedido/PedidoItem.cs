using NetLanches.Domain.Produtos;

namespace NetLanches.Domain.Pedido;

public class PedidoItem
{
    public string Descricao { get; }
    public int Quantidade { get; private set; }
    public double PrecoUnitario { get; }

    public PedidoItem(ItemCardapio item, int quantidade)
    {
        Descricao = item.ObterDescricao();
        PrecoUnitario = item.ObterPrecoFinal();
        Quantidade = quantidade;
    }

    public void AdicionarQuantidade(int quantidade)
    {
        Quantidade += quantidade;
    }

    public double Subtotal => Quantidade * PrecoUnitario;
}