namespace NetLanches.Domain.Produtos;

public class Lanches : ItemCardapio
{
    public Dictionary<string, double> Sabores { get; } = new();
    public Dictionary<string, double> Ingredientes { get; } = new();

    private string saborSelecionado = "";
    private string ingredienteSelecionado = "";
    private double valorExtraSabor = 0;
    private double valorExtraIngrediente = 0;

    public Lanches(int id, string nome, double preco, string descricao)
        : base(id, nome, preco, descricao)
    {
    }

    public void SelecionarSabor(string sabor, double valorExtra)
    {
        saborSelecionado = sabor;
        valorExtraSabor = valorExtra;
    }

    public void SelecionarIngrediente(string ingrediente, double valorExtra)
    {
        ingredienteSelecionado = ingrediente;
        valorExtraIngrediente = valorExtra;
    }

    public override double ObterPrecoFinal()
        => Preco + valorExtraSabor + valorExtraIngrediente;

    public override string ObterDescricao()
    {
        string descricao = Nome;

        if (!string.IsNullOrEmpty(saborSelecionado))
            descricao += $" ({saborSelecionado})";

        if (!string.IsNullOrEmpty(ingredienteSelecionado))
            descricao += $" + {ingredienteSelecionado}";

        return descricao;
    }

    public override ItemCardapio Clonar()
    {
        var clone = new Lanches(Id, Nome, Preco, Descricao);

        foreach (var sabor in Sabores)
            clone.Sabores.Add(sabor.Key, sabor.Value);
        foreach (var ingrediente in Ingredientes)
            clone.Ingredientes.Add(ingrediente.Key, ingrediente.Value);

        clone.SelecionarSabor(saborSelecionado, valorExtraSabor);
        clone.SelecionarIngrediente(ingredienteSelecionado, valorExtraIngrediente);

        return clone;
    }
}