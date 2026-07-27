using Cafeteria.modelo;

namespace Cafeteria.controle;

public static class ItemControle
{
    private static List<Item> CARDAPIO = new List<Item>();
    private static int _identificador = 1;


    public static void CadastrarItem(string nome, string descricao, double preco, Tipo tipo)
    {
        if(preco <= 0)
            throw new ArgumentException("Item não pode ser menor ou igual a zero");
        if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O campo nome é obrigatorio");
        
        CARDAPIO.Add(new Item(_identificador++, nome, descricao, preco, tipo));
    }

    public static void DeletarItem(int id)
    {
       Item itemEncontrado = CARDAPIO.Find(x => x.Id == id) ?? throw new ArgumentException("Item não encontrado");
       CARDAPIO.Remove(itemEncontrado);
    }

    public static  List<Item> ListarItems()
    {
        return new List<Item>(CARDAPIO);
    }
    

    public static void AlterarItem(Item item)
    {
        Item itemEncontrado = CARDAPIO.Find(x => x.Id == item.Id) ?? throw new ArgumentException("Item não encontrado");
        itemEncontrado.Nome = item.Nome;
        itemEncontrado.Descricao = item.Descricao;
        itemEncontrado.Preco = item.Preco;
        itemEncontrado.Tipo = item.Tipo;
    }

    public static void MudarDisponibilidade(int id)
    {
        Item itemEncontrado = CARDAPIO.Find(x => x.Id == id) ?? throw new ArgumentException("Item não encontrado");
        itemEncontrado.MudarDisponibilidade();
    }

    public static double AplicarDesconto(int id,double procentagem)
    {
        if (procentagem > 30) throw new ArgumentException("Não são permitidos descontos acima de 30%");
        Item itemEncontrado = CARDAPIO.Find(x => x.Id == id) ?? throw new ArgumentException("Item não encontrado");
        return itemEncontrado.Preco - ((procentagem / 100) * itemEncontrado.Preco);
    }

    public static Item PegarItem(int id)
    {
        Item itemEncontrado = CARDAPIO.Find(x => x.Id == id) ?? throw new ArgumentException("Item não encontrado");
        return new Item(itemEncontrado.Id, itemEncontrado.Nome, itemEncontrado.Descricao,itemEncontrado.Preco, itemEncontrado.Tipo);
    }
    
}