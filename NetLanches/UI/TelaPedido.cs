using NetLanches.Domain.Pedido;
using NetLanches.Domain.Produtos;
using NetLanches.Modelos;

namespace NetLanches.UI;

public class TelaPedido
{
    private readonly Cardapio cardapio = new();
    private readonly Pedido pedidoAtual = new();

    public void Mostrar()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            ConsoleHelper.MostrarLogo();
            Console.WriteLine("\n===== CARDÁPIO =====\n");

            // Mostrar itens do cardápio
            foreach (var item in cardapio.Itens)
            {
                Console.WriteLine($"{item.Id} - {item.Nome} | R$ {item.Preco:F2}");
                Console.WriteLine(item.Descricao);
                Console.WriteLine();
            }

            // Ler item
            int idSelecionado = ConsoleHelper.LerInteiro("Digite o número do item desejado: ");
            var itemEscolhido = cardapio.Itens.FirstOrDefault(i => i.Id == idSelecionado);

            if (itemEscolhido == null)
            {
                ConsoleHelper.MostrarErro();
                continue;
            }
            var itemParaPedido = itemEscolhido.Clonar();

            if (itemParaPedido is Lanches lanche)
            {
                if (lanche.Sabores.Any())
                {
                    int idxSabor = ConsoleHelper.LerOpcaoLista(
                        lanche.Sabores.ToList(),
                        s => $"{s.Key} (+ R$ {s.Value:F2})",
                        "Escolha o sabor:"
                    );
                    lanche.SelecionarSabor(lanche.Sabores.ElementAt(idxSabor).Key,
                                           lanche.Sabores.ElementAt(idxSabor).Value);
                }

                if (lanche.Ingredientes.Any())
                {
                    int idxIng = ConsoleHelper.LerOpcaoLista(
                        lanche.Ingredientes.ToList(),
                        i => $"{i.Key} (+ R$ {i.Value:F2})",
                        "Escolha ingrediente adicional:"
                    );
                    lanche.SelecionarIngrediente(lanche.Ingredientes.ElementAt(idxIng).Key,
                                                 lanche.Ingredientes.ElementAt(idxIng).Value);
                }
            }

            if (itemParaPedido is Bebidas bebida)
            {
                if (bebida.Sabores.Any())
                {
                    int idxSabor = ConsoleHelper.LerOpcaoLista(
                        bebida.Sabores.ToList(),
                        s => s.Key,
                        "Escolha o sabor:"
                    );
                    bebida.SelecionarSabor(bebida.Sabores.ElementAt(idxSabor).Key);
                }

                if (bebida.Tamanhos.Any())
                {
                    int idxTam = ConsoleHelper.LerOpcaoLista(
                        bebida.Tamanhos.ToList(),
                        t => $"{t.Key} (+ R$ {t.Value:F2})",
                        "Escolha o tamanho:"
                    );
                    bebida.SelecionarTamanho(bebida.Tamanhos.ElementAt(idxTam).Key,
                                             bebida.Tamanhos.ElementAt(idxTam).Value);
                }
            }

            int quantidade = ConsoleHelper.LerInteiro("Quantidade: ");
            if (quantidade <= 0)
            {
                ConsoleHelper.MostrarErro("Quantidade inválida!");
                continue;
            }

            var existente = pedidoAtual.ObterItens()
                .FirstOrDefault(p => p.Descricao == itemParaPedido.ObterDescricao() &&
                                     p.PrecoUnitario == itemParaPedido.ObterPrecoFinal());

            if (existente != null)
            {
                existente.AdicionarQuantidade(quantidade);
                Console.WriteLine($"\nAtualizado: {existente.Quantidade}x {existente.Descricao}");
            }
            else
            {
                pedidoAtual.AdicionarItem(new PedidoItem(itemParaPedido, quantidade));
                Console.WriteLine($"\nAdicionado: {quantidade}x {itemParaPedido.ObterDescricao()}");
            }
            Console.WriteLine($"Subtotal: R$ {pedidoAtual.CalcularTotal():F2}\n");

            // Pergunta se deseja continuar
            bool respostaValida = false;
            while (!respostaValida)
            {
                Console.Write("Deseja adicionar mais itens? (s/n): ");
                var resposta = Console.ReadLine()?.Trim().ToLower();
                if (resposta == "s") respostaValida = true;
                else if (resposta == "n")
                {
                    respostaValida = true;
                    continuar = false;
                }
                else
                {
                    ConsoleHelper.MostrarErro();
                }
            }
        }

        MostrarResumo();
    }

    private void MostrarResumo()
    {
        Console.Clear();
        ConsoleHelper.MostrarLogo();
        Console.WriteLine("\n===== RESUMO DO PEDIDO =====\n");

        foreach (var item in pedidoAtual.ObterItens())
        {
            Console.WriteLine($"{item.Quantidade}x {item.Descricao} - R$ {item.Subtotal:F2}");
        }

        Console.WriteLine($"\nTotal a pagar: R$ {pedidoAtual.CalcularTotal():F2}");
        Console.WriteLine("\nObrigado pela preferência! =) ");
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        pedidoAtual.Clear();
        Console.ReadKey();
    }
}