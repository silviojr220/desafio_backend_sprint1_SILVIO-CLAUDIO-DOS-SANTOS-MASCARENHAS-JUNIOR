namespace NetLanches.Modelos;

public static class ConsoleHelper
{
    public static void MostrarErro(string mensagem = "Opção inválida!")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensagem);
        Console.ResetColor();
        Console.ReadKey(true);
    }

    public static int LerInteiro(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            if (int.TryParse(Console.ReadLine(), out int valor)) return valor;
            MostrarErro("Digite um número válido.");
        }
    }

    public static int LerOpcaoLista<T>(
     List<T> lista,
     Func<T, string> exibicao,
     string titulo = "Escolha uma opção:",
     bool mostrarOpcaoSair = false,
     int opcaoSair = -1
 )
    {
        while (true)
        {
            Console.Clear();
            MostrarLogo();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n═════ {titulo} ═════\n");
            Console.ResetColor();

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i} - {exibicao(lista[i])}");
            }

            if (mostrarOpcaoSair)
            {
                Console.WriteLine($"{opcaoSair} - Sair");
            }

            Console.Write("\nDigite o número: ");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                if (mostrarOpcaoSair && escolha == opcaoSair)
                    return opcaoSair;

                if (escolha >= 0 && escolha < lista.Count)
                    return escolha;
            }

            MostrarErro();
        }
    }

    public static void MostrarLogo()
    {
        Console.Clear();
        string logo1 = "\x1b[37m███╗  ██╗███████╗████████╗\x1b[0m  \x1b[38;5;214m██╗      █████╗ ███╗  ██╗ █████╗ ██╗  ██╗███████╗ ██████╗\x1b[0m";
        string logo2 = "\x1b[37m████╗ ██║██╔════╝╚══██╔══╝\x1b[0m  \x1b[38;5;226m██║     ██╔══██╗████╗ ██║██╔══██╗██║  ██║██╔════╝██╔════╝\x1b[0m";
        string logo3 = "\x1b[37m██╔██╗██║█████╗     ██║   \x1b[0m  \x1b[38;5;9m██║     ███████║██╔██╗██║██║  ╚═╝███████║█████╗  ╚█████╗ \x1b[0m";
        string logo4 = "\x1b[37m██║╚████║██╔══╝     ██║   \x1b[0m  \x1b[38;5;47m██║     ██╔══██║██║╚████║██║  ██╗██╔══██║██╔══╝   ╚═══██╗\x1b[0m";
        string logo5 = "\x1b[37m██║ ╚███║███████╗   ██║   \x1b[0m  \x1b[38;5;214m███████╗██║  ██║██║ ╚███║╚█████╔╝██║  ██║███████╗██████╔╝\x1b[0m";
        string logo6 = "\x1b[37m╚═╝  ╚══╝╚══════╝   ╚═╝   \x1b[0m  \x1b[38;5;208m╚══════╝╚═╝  ╚═╝╚═╝  ╚══╝ ╚════╝ ╚═╝  ╚═╝╚══════╝╚═════╝ \x1b[0m";

        Console.WriteLine($"{logo1}");
        Console.WriteLine($"{logo2}");
        Console.WriteLine($"{logo3}");
        Console.WriteLine($"{logo4}");
        Console.WriteLine($"{logo5}");
        Console.WriteLine($"{logo6}");
    }

    public static void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}