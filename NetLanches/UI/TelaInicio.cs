using NetLanches.Modelos;

namespace NetLanches.UI;

public class TelaInicio
{
    private readonly TelaPedido telaPedido = new();

    public void Mostrar()
    {
        int opcao = 0;

        while (opcao != 3)
        {
            Console.Clear();

            ConsoleHelper.MostrarLogo();
            Console.WriteLine("\n==- Bem vindo ao NetLanches! -==\n");

            Console.WriteLine("1 - Fazer Pedido");
            Console.WriteLine("2 - Sair");
            Console.Write("Escolha: ");

            int.TryParse(Console.ReadLine(), out opcao);

            if (opcao == 1)
                telaPedido.Mostrar();
        }
    }
}