namespace NetLanches.Domain.Produtos;

public class ItemCardapio
{
    public int Id { get; }
    public string Nome { get; }
    public double Preco { get; }
    public string Descricao { get; }

    public ItemCardapio(int id, string nome, double preco, string descricao)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Descricao = descricao;
    }

    public virtual double ObterPrecoFinal() => Preco;

    public virtual string ObterDescricao() => Nome;
    public virtual ItemCardapio Clonar()
    {
        return new ItemCardapio(Id, Nome, Preco, Descricao);
    }
}