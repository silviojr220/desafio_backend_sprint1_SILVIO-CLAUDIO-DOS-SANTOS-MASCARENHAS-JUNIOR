namespace NetLanches.Domain.Produtos;

public class Lanches : ItemCardapio
{
    public Dictionary<string, double> Sabores { get; } = new();
    public Dictionary<string, double> Ingredientes { get; } = new();

    private string saborSelecionado = "";
    private List<KeyValuePair<string, double>> ingredientesSelecionados = new();
    private double valorExtraSabor = 0;
    private double valorExtraIngrediente = 0;
    private string ingredienteSelecionado = "";

    public Lanches(int id, string nome, double preco, string descricao)
        : base(id, nome, preco, descricao)
    {
    }

    public void AdicionarIngrediente(string nome, double preco)
    {
        ingredientesSelecionados.Add(new KeyValuePair<string, double>(nome, preco));
    }

    public void RemoverIngrediente(int index)
    {
        if (index >= 0 && index < ingredientesSelecionados.Count)
            ingredientesSelecionados.RemoveAt(index);
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

    public List<KeyValuePair<string, double>> ObterIngredientesSelecionados()
    {
        return new List<KeyValuePair<string, double>>(ingredientesSelecionados);
    }

    public override double ObterPrecoFinal()
    {
        double extras = ingredientesSelecionados.Sum(i => i.Value);
        return Preco + valorExtraSabor + extras;
    }

    public override string ObterDescricao()
    {
        string descricao = Nome;

        if (!string.IsNullOrEmpty(saborSelecionado))
            descricao += $" ({saborSelecionado})";

        if (ingredientesSelecionados.Any())
            descricao += " + " + string.Join(", ", ingredientesSelecionados.Select(i => i.Key));

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

        foreach (var ing in ingredientesSelecionados)
            clone.AdicionarIngrediente(ing.Key, ing.Value);

        return clone;
    }
}