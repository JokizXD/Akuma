using System;

interface IAtaque 
{
    void AtaqueNormal();
}

public abstract class Heroi 
{
    protected string nome;
    private int nivel;
    private int vida;
    private int mana;

    public Heroi(string nome, int nivel, int vida, int mana) 
    {
        this.nome = nome;
        this.nivel = nivel;
        this.vida = vida;
        this.mana = mana;
    }

    public string GetNome()
    {
        return nome;
    }
    
    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public int GetNivel()
    {
        return nivel;
    }
    
    public void SetNivel(int nivel)
    {
        this.nivel = nivel;
    }

    public int GetVida()
    {
        return vida;
    }
    
    public void SetVida(int vida)
    {
        this.vida = vida;
    }

    public int GetMana()
    {
        return mana;
    }
    
    public void SetMana(int mana)
    {
        this.mana = mana;
    }

    public void ReceberDano(int dano) 
    {
        vida -= dano;
        Console.WriteLine($"{nome} recebeu {dano} de dano e agora tem {vida} de vida.");
        if (vida <= 0) 
        {
            Morrer();
        }
    }

    public void GastarMana(int menosmana) 
    {
        mana -= menosmana;
        Console.WriteLine($"{nome} gastou {menosmana} de energia amaldiçoada e agora tem {mana} de energia amaldiçoada.");
        if (mana <= 0) 
        {
            Desmaiar();
        }
    }
    
    public abstract void AtaqueEspecial(); 

    public void Morrer() 
    {
        Console.WriteLine($"{nome} morreu!");
    }

    public void Desmaiar() 
    {
        Console.WriteLine($"{nome} desmaiou!");
    }
}

public class Guerreiro : Heroi, IAtaque 
{
    public Guerreiro(string nome, int nivel, int vida, int mana)  : base(nome, nivel, vida, mana) {}

    public void AtaqueNormal() 
    {
        Console.WriteLine($"{nome} Ataca com sua espada!");
    }

    public override void AtaqueEspecial() 
    {
        Console.WriteLine($"{nome} Usa A Espada Darkin!");
    }
}

public class Mago : Heroi, IAtaque 
{
    public Mago(string nome, int nivel, int vida, int mana)  : base(nome, nivel, vida, mana) {}

    public void AtaqueNormal() 
    {
        Console.WriteLine($"{nome} Ataca com sua bola de fogo!");
    }

    public override void AtaqueEspecial() 
    {
        Console.WriteLine($"{nome} Usa A Grande Bola de Fogo do Caos!");
    }
}

public class Arqueiro : Heroi, IAtaque 
{
    public Arqueiro(string nome, int nivel, int vida, int mana)  : base(nome, nivel, vida, mana) {}

    public void AtaqueNormal() 
    {
        Console.WriteLine($"{nome} Dispara uma flecha!");
    }

    public override void AtaqueEspecial() 
    {
        Console.WriteLine($"{nome} Usa Tempestade de Flechas");
    }
}

public class Program
{
    public static void Main()
    {
        Guerreiro guerreiro = new Guerreiro("Aatrox", 18, 2000, 99999);
        Mago mago = new Mago("Lorde das Cinzas", 17, 1500, 16000);
        Arqueiro arqueiro = new Arqueiro("Varus", 14, 750, 5000);

        guerreiro.AtaqueNormal();
        guerreiro.AtaqueEspecial();
        mago.AtaqueNormal();
        mago.AtaqueEspecial();
        arqueiro.AtaqueNormal();
        arqueiro.AtaqueEspecial();

        guerreiro.ReceberDano(750);
        guerreiro.GastarMana(1000);
        mago.ReceberDano(500);
        mago.GastarMana(300);
        arqueiro.ReceberDano(750);
        arqueiro.GastarMana(100);
    }
}