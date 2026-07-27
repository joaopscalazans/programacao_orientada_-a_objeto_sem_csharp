using System.Xml.Schema;
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
                    AlterarItem();
                    break;
                case "4":
                    AplicarDesconto();
                    break;
                case "5":
                    PauseReativar();
                    break;
                case "6":
                    Remove();
                    break;
                default: Console.WriteLine("Opção invalida");
                    Console.ReadKey(); break;
            }
        }
    }

    public static void Remove()
    {
        try
        {
            Console.WriteLine("Qual é o id do item");
            ItemControle.DeletarItem(int.TryParse(Console.ReadLine(), out int id) ? id : throw new Exception("Valor invalido"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
        }
    }

    public static void PauseReativar()
    {
        try
        {
            Console.WriteLine("Qual é o id do item:");
            ItemControle.MudarDisponibilidade(int.TryParse(Console.ReadLine(), out int id) ? id : throw new Exception("Valor invalido"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
        }
    }

    public static void AplicarDesconto()
    {
        try
        {
            Console.Write("Qual o id do item: ");
            int id = int.TryParse(Console.ReadLine(), out int valor) ? valor : throw new Exception("Valor invalido");
            Console.Write("Desconto: ");
            double desconto = double.TryParse(Console.ReadLine(), out double val)
                ? val
                : throw new Exception("Valor invalido");
            double vari = ItemControle.AplicarDesconto(id, val);
            Console.Write($"O valor do desconto vai ser: {vari} ");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.ReadKey();
    }

    public static void AlterarItem()
    {
        Console.WriteLine("Alterar item");
        try
        {
            Console.WriteLine("Qual o id do item:");
            var item = ItemControle.PegarItem(int.TryParse(Console.ReadLine(), out int id) ? id : throw new Exception("Valor invalido"));
            Console.WriteLine("Você quer alterar o Nome? (s/n)");
            if (Console.ReadLine() == "s")
            {
                Console.Write("Nome: ");
                item.Nome  = Console.ReadLine();
            }
            Console.WriteLine("Você quer alterar o Descrição? (s/n)");
            if (Console.ReadLine() == "s")
            {
                Console.WriteLine("Descricao: ");
                item.Descricao  = Console.ReadLine();
            }
            Console.WriteLine("Você quer alterar o Preço? (s/n)");
            if (Console.ReadLine() == "s")
            {
                Console.WriteLine("Preco: ");
                item.Preco = double.TryParse(Console.ReadLine(), out double valor) ? valor : throw new Exception("Valor invalido");
            }
            Console.WriteLine("Você quer alterar o Tipo? (s/n)");
            if (Console.ReadLine() == "s")
            {
                Console.WriteLine("Tipo: ");
                item.Tipo = MenuInterrativoTipo();
            }
            ItemControle.AlterarItem(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
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

