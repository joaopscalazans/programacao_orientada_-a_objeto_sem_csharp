namespace Cafeteria.modelo;

public class Item
{
    public int Id { get; private set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }  
    public double  Preco { get; set; }
    public Tipo Tipo { get; set; }

    public Item()
    {
    }

    public Item(int id, string nome, string descricao, double preco, Tipo tipo)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Tipo = tipo;
    }
}