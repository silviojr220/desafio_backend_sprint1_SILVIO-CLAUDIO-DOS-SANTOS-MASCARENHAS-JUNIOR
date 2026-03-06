using NetLanches.Domain.Produtos;
using NetLanches.Modelos;

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
        //-- Lanches / Salgados --
        var coxinha = new Lanches(1, "Coxinha", 3.50, "Coxinha crocante recheada com frango desfiado temperado");
        var kibe = new Lanches(2, "Kibe", 3.00, "Kibe frito crocante feito com carne temperada e trigo");
        var pastel = new Lanches(3, "Pastel", 5.00, "Pastel frito na hora com massa crocante");
        var enroladinho = new Lanches(4, "Enroladinho de Salsicha", 3.00, "Salsicha enrolada em massa macia e frita");
        var esfiha = new Lanches(5, "Esfiha", 4.00, "Esfiha assada com recheio tradicional");
        var hamburguer = new Lanches(6, "Hambúrguer", 8.00, "Pão, carne bovina grelhada, alface e tomate");

        //-- Bebidas --
        var refrigerante = new Bebidas(7, "Refrigerante", 4.00, "Refrigerante gelado em lata");
        var suco = new Bebidas(8, "Suco Natural", 6.00, "Suco natural feito com frutas frescas");
        var agua = new Bebidas(9, "Água Mineral", 2.50, "Água mineral sem gás");

        //-- Sabores de Pastel --
        pastel.Sabores.Add("Frango", 0);
        pastel.Sabores.Add("Carne", 0);
        pastel.Sabores.Add("Queijo", 1);
        pastel.Sabores.Add("Pizza (presunto + queijo)", 1.50);
        pastel.Sabores.Add("Frango com Catupiry", 2);

        //-- Sabores de Esfiha --
        esfiha.Sabores.Add("Carne", 0);
        esfiha.Sabores.Add("Frango", 0);
        esfiha.Sabores.Add("Calabresa", 1);

        //-- Sabores de Refrigerante --
        refrigerante.Sabores.Add("Coca-Cola", 0);
        refrigerante.Sabores.Add("Guaraná", 0);
        refrigerante.Sabores.Add("Fanta Laranja", 0);
        refrigerante.Sabores.Add("Fanta Uva", 0);
        refrigerante.Sabores.Add("Sprite", 0);

        //-- Sabores de Suco --
        suco.Sabores.Add("Laranja", 0);
        suco.Sabores.Add("Maracujá", 0);
        suco.Sabores.Add("Acerola", 0);
        suco.Sabores.Add("Manga", 0);

        //-- Ingredientes adicionais (para lanches) --
        coxinha.Ingredientes.Add("Catupiry", 2);
        coxinha.Ingredientes.Add("Cheddar", 2);
        coxinha.Ingredientes.Add("Bacon", 3);

        pastel.Ingredientes.Add("Catupiry", 2);
        pastel.Ingredientes.Add("Cheddar", 2);
        pastel.Ingredientes.Add("Bacon", 3);
        pastel.Ingredientes.Add("Milho", 1);
        pastel.Ingredientes.Add("Ervilha", 1);
        pastel.Ingredientes.Add("Calabresa", 2);

        hamburguer.Ingredientes.Add("Queijo", 2);
        hamburguer.Ingredientes.Add("Bacon", 3);
        hamburguer.Ingredientes.Add("Ovo", 2);
        hamburguer.Ingredientes.Add("Presunto", 2);
        hamburguer.Ingredientes.Add("Molho especial", 1);

        //-- Tamanhos de bebida --
        refrigerante.Tamanhos.Add("Pequeno", 0);
        refrigerante.Tamanhos.Add("Médio", 1);
        refrigerante.Tamanhos.Add("Grande", 2);

        suco.Tamanhos.Add("300ml", 0);
        suco.Tamanhos.Add("500ml", 2);

        //-- Adicionando ao cardápio --
        Itens.AddRange(new ItemCardapio[]
{
    coxinha,
    kibe,
    pastel,
    enroladinho,
    esfiha,
    hamburguer,
    refrigerante,
    suco,
    agua
});

    }

    public void MostrarSimples()
    {
        Console.Clear();
        ConsoleHelper.MostrarLogo();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n═══════════ CARDÁPIO ═══════════\n");
        Console.ResetColor();

        foreach (var item in Itens)
        {
            string nome = item.Nome;
            string preco = $"R$ {item.Preco:F2}";

            int larguraTotal = 32;

            int pontos = larguraTotal - nome.Length - preco.Length;

            if (pontos < 0) pontos = 2;

            string linha = nome + new string('.', pontos) + preco;

            Console.WriteLine(linha);
        }

        Console.WriteLine("\n════════════════════════════════\n");
        ConsoleHelper.Pausar();
    }

}