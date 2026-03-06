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

    public double CalcularDesconto()
    {
        double total = CalcularTotal();

        if (total >= 100)
            return total * 0.15; //15% de desconto

        if (total >= 50)
            return total * 0.10; //10% de desconto

        if (total >= 30)
            return total * 0.05; //5% de desconto

        return 0;
    }

    public double CalcularTotalComDesconto()
    {
        return CalcularTotal() - CalcularDesconto();
    }
    public void Clear()
    {

        itens.Clear();
    }


}