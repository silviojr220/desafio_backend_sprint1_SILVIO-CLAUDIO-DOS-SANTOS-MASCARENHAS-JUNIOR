namespace NetLanches.Domain.Produtos;

public class Bebidas : ItemCardapio
{
    public Dictionary<string, double> Tamanhos { get; } = new();
    public Dictionary<string, double> Sabores { get; } = new();

    private string saborSelecionado = "";
    private string tamanhoSelecionado = "";
    private double valorExtra = 0;

    public Bebidas(int id, string nome, double preco, string descricao)
        : base(id, nome, preco, descricao)
    {
    }

    public void SelecionarSabor(string sabor)
    {
        saborSelecionado = sabor;
    }

    public void SelecionarTamanho(string tamanho, double valorExtra)
    {
        tamanhoSelecionado = tamanho;
        this.valorExtra = valorExtra;
    }

    public override double ObterPrecoFinal()
        => Preco + valorExtra;

    public override string ObterDescricao()
        => $"{Nome} - {saborSelecionado} ({tamanhoSelecionado})";

    public override ItemCardapio Clonar()
    {
        var clone = new Bebidas(Id, Nome, Preco, Descricao);

        foreach (var sabor in Sabores)
            clone.Sabores.Add(sabor.Key, sabor.Value);
        foreach (var tamanho in Tamanhos)
            clone.Tamanhos.Add(tamanho.Key, tamanho.Value);

        clone.SelecionarSabor(saborSelecionado);
        clone.SelecionarTamanho(tamanhoSelecionado, valorExtra);

        return clone;
    }
}