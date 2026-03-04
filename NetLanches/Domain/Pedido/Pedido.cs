namespace NetLanches.Domain.Pedido;

public class Pedido
{
    private readonly List<PedidoItem> itens = new();

    public void AdicionarItem(PedidoItem item)
    {
        itens.Add(item);
    }

    public List<PedidoItem> ObterItens() => itens;

    public double CalcularTotal()
        => itens.Sum(i => i.Subtotal);

    public void Clear()
    {

        itens.Clear();
    }
}