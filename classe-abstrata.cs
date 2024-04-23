using System;

public abstract class Ser 
{
    private string nome;
    private string classe;
    private int vida;
    private int energia;

    public Ser(string nome, string classe, int vida, int energia) 
    {
        this.nome = nome;
        this.classe = classe;
        this.vida = vida;
        this.energia = energia;
    }

    public string GetNome()
    {
        return nome;
    }
    
    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public string GetClasse()
    {
        return classe;
    }

    public void SetClasse(string classe)
    {
        this.classe = classe;
    }

    public int GetVida()
    {
        return vida;
    }

    public void SetVida(int vida)
    {
        this.vida = vida;
    }

    public int GetEnergia()
    {
        return energia;
    }

    public void SetEnergia(int energia)
    {
        this.energia = energia;
    }
    
    public abstract void AtaqueCorpo(); 
    public abstract void AtaqueEnergia(); 

    public void ReceberDano(int dano) 
    {
        vida -= dano;
        Console.WriteLine($"{nome} recebeu {dano} de dano e agora tem {vida} de vida.");
        if (vida <= 0) 
        {
            Morrer();
        }
    }

    public void GastarEnergia(int menosenergia) 
    {
        energia -= menosenergia;
        Console.WriteLine($"{nome} gastou {menosenergia} de energia amaldiçoada e agora tem {energia} de energia amaldiçoada.");
        if (energia <= 0) 
        {
            Desmaiar();
        }
    }

    public void Morrer() 
    {
        Console.WriteLine($"{nome} morreu!");
    }

    public void Desmaiar() 
    {
        Console.WriteLine($"{nome} desmaiou!");
    }
}

public class Feiticeiro : Ser 
{
    public Feiticeiro(string nome, string classe, int vida, int energia)  : base(nome, classe, vida, energia) {}

    public override void AtaqueCorpo() 
    {
        Console.WriteLine($"{GetNome()} ataca com sua Bola de Basquete amaldiçoada de grau especial!");
    }

    public override void AtaqueEnergia() 
    {
        Console.WriteLine($"{GetNome()} dribla com sua Bola de Basquete aumentando sua força!");
    }
}

public class Maldicao : Ser 
{
    public Maldicao(string nome, string classe, int vida, int energia)  : base(nome, classe, vida, energia) {}

    public override void AtaqueCorpo() 
    {
        Console.WriteLine($"{GetNome()} usa o Corte Marmitex");
    }

    public override void AtaqueEnergia() 
    {
        Console.WriteLine($"{GetNome()} expande seu dominio da Marmitaria Divina!");
    }
}

public class Program
{
    public static void Main()
    {
        Feiticeiro feiticeiro = new Feiticeiro("David", "Grau 4", 100, 1000);
        Maldicao maldicao = new Maldicao("Asafe", "Classe Especial", 200, 16000);

        feiticeiro.AtaqueCorpo();
        feiticeiro.AtaqueEnergia();
        maldicao.AtaqueCorpo();
        maldicao.AtaqueEnergia();

        feiticeiro.ReceberDano(200);
        feiticeiro.GastarEnergia(100);
        maldicao.ReceberDano(5);
        maldicao.GastarEnergia(16000);
    }
}