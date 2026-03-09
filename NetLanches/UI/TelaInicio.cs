using NetLanches.Domain.Pedido;
using NetLanches.Domain.Produtos;
using NetLanches.Modelos;

namespace NetLanches.UI;

public class TelaInicio
{
    private readonly Cardapio cardapio = new();
    private readonly TelaPedido telaPedido = new();

    public void Mostrar()
    {
        int opcao = 0;

        while (opcao != 3)
        {
            Console.Clear();

            ConsoleHelper.MostrarLogo();
            Console.WriteLine("\n═══════════════════════════════════");
            Console.WriteLine("\n▓▒░| \x1b[1mBem vindo ao NetLanches!\x1b[0m |░▒▓\n");
            Console.WriteLine("1 ┬ Fazer Pedido");
            Console.WriteLine("2 ┼ Mostrar Cardapio");
            Console.WriteLine("3 ┴ \x1b[38;5;196mSair\x1b[0m");
            Console.WriteLine("\n═══════════════════════════════════\n");
            Console.Write("Escolha: ");

            int.TryParse(Console.ReadLine(), out opcao);

            if (opcao == 1)
            {
                telaPedido.Mostrar();
            }

            else if (opcao == 2)
            {
                cardapio.MostrarSimples();
            }

        }
    }



}