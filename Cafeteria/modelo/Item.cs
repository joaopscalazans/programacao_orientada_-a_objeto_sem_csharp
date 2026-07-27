namespace Cafeteria.modelo;

public class Item
{
    public int Id { get; private set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }  
    public double  Preco { get; set; }
    public bool EstaDisponivel { get; private set; }
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
        EstaDisponivel = true;
    }

    public void MudarDisponibilidade()
    {
        if (EstaDisponivel)
        {
            EstaDisponivel = false;
        }
        else
        {
            EstaDisponivel = true;
        }
    }

    public override string ToString()
    {
        return $"| {Id,-2} | {Nome,-15} | {Descricao,-15} | {Preco,-10:C2} | {Tipo,-7} | {((EstaDisponivel == true) ? "Disponivel" : "indisponivel"), -5}";
    }
}