using Cafeteria.controle;
using Cafeteria.modelo;

namespace Cafeteria;

class Program
{
    static void Main(string[] args)
    {
        ConfigurarTamanhoTerminal(120,40);
        Console.WriteLine("Cafeteria");
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1 ) - Cadastrar novo item");
            Console.WriteLine("2 ) - Listar Cardápio");
            Console.WriteLine("3 ) - Alterar item");
            Console.WriteLine("4 ) - Aplicar desconto");
            Console.WriteLine("5 ) - Pausa / Reativar item");
            Console.WriteLine("6 ) - Remover item");
            Console.WriteLine("0 ) - Sair");
            var opcao = Console.ReadLine();

            if (opcao == "0") break;

            switch (opcao)
            {
                case "1":
                    CadastrarItem();
                    break;
                case "2":
                    ListarCardapio();
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                default: break;
            }
        }
    }

    private static void ListarCardapio()
    {
        Console.Clear();
        Console.WriteLine("=======================================");
        Console.WriteLine("Cardápio");
        ItemControle.ListarItems().ForEach(x => Console.WriteLine(x));
        Console.WriteLine("======================================");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private static void CadastrarItem()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("Cadastrar novo item:");
        try
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Descricao: ");
            string descricao = Console.ReadLine();
            Console.Write("Preco: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Tipo: ");
            Tipo tipo = MenuInterrativoTipo();
            
            ItemControle.CadastrarItem(nome, descricao, preco, tipo);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
        }
        Console.WriteLine("Item cadastrado com sucesso!");
    }


    //Daqui pra baixo foi feito com auxilo de IA e muita gambiarra !! NÃO MEXA CONTEUDO FRÁGIL!!
    private static Tipo MenuInterrativoTipo()
    {
        string[] tipos = ["Bebidas", "Salgados", "Sobremesas"];
        var selecao = 0;
        int posicao = Console.CursorTop;
        bool escolhendo = true;
        while (escolhendo)
        {
            Console.SetCursorPosition(0, posicao);
           
            for (int i = 0; i < tipos.Length; i++)
            {
                string textoOpcao = (i == selecao) ? $" > {tipos[i]} < " : $"   {tipos[i]}   ";
                textoOpcao = textoOpcao.PadRight(30);

                if (i == selecao)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($" > {tipos[i]} < ");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"   {tipos[i]}   ");
                }
            }

            ConsoleKeyInfo tecla = Console.ReadKey(true);

            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    selecao--;
                    if (selecao < 0) selecao = tipos.Length - 1;
                    break;

                case ConsoleKey.DownArrow:
                    selecao++;
                    if (selecao >= tipos.Length) selecao = 0;
                    break;

                case ConsoleKey.Enter:
                    escolhendo = false;
                    break;
            }
        }
        return (Tipo)selecao;
    }
    private static void ConfigurarTamanhoTerminal(int largura, int altura)
    {
        if (OperatingSystem.IsWindows())
        {
            Console.SetWindowSize(largura, altura);
            Console.SetBufferSize(largura, altura); // Remove barras de rolagem
        }
    }
}

