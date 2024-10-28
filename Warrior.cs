using System;
// Classe base Guerreiro.
public class Warrior
{
    public string Name { get; set; }
    public int Attack { get; set;}
    public int Defense { get; set; }
    public int Health { get; set; }
    public int DamageTook { get; set; }

    public Warrior(string name, int attack, int defense, int health)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        Health = health;
        DamageTook = 0;
    }

    public virtual void TakeDamage(int damage) // Método para receber dano.
    {
        int finalDamage = Math.Max(damage - Defense, 0);
        Health -= finalDamage;
        if (Health < 0) Health = 0;
        DamageTook = finalDamage;
        Console.WriteLine($"{Name} recebeu {finalDamage} de dano. Vida restante: {Health}");
    }

    public virtual void ToAttack(Warrior target) // Método para atacar o inimigo.
    {
        Console.WriteLine($"{Name} ataca {target.Name} com {Attack} de poder.");
        target.TakeDamage(Attack);
    }

    public virtual bool BeAlive() => Health > 0; // Método para verificar se o warrior está vivo ou morto.
}
