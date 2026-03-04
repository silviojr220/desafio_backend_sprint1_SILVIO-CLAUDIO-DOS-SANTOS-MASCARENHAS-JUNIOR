using NetLanches.Domain.Produtos;

namespace NetLanches.UI;

public class Cardapio
{
    public List<ItemCardapio> Itens { get; } = new();

    public Cardapio()
    {
        Criar();
    }

    private void Criar()
    {
        var coxinha = new ItemCardapio(1, "Coxinha", 3.50, "Com frango");
        var kibe = new ItemCardapio(2, "Kibe", 3.00, "Frito");

        var pastel = new Lanches(3, "Pastel", 5.00, "Frito na hora");
        pastel.Sabores.Add("Frango", 0);
        pastel.Sabores.Add("Carne", 0);
        pastel.Sabores.Add("Queijo", 1);

        var refrigerante = new Bebidas(4, "Refrigerante", 4.00, "Lata");
        refrigerante.Sabores.Add("Coca", 0);
        refrigerante.Sabores.Add("Guaraná", 0);
        refrigerante.Tamanhos.Add("Pequeno", 0);
        refrigerante.Tamanhos.Add("Grande", 2);

        Itens.AddRange(new[] { coxinha, kibe, pastel, refrigerante });
    }
}