using System;

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

    public virtual void TakeDamage(int damage)
    {
        int finalDamage = Math.Max(damage - Defense, 0);
        Health -= finalDamage;
        DamageTook = finalDamage;
        Console.WriteLine($"{Name} recebeu {finalDamage} de dano. Vida restante: {Vida}");
    }

    public virtual void ToAttack(Warrior target)
    {
        Console.WriteLine($"{Name} ataca {target.Name} com {Attack} de poder.");
        target.TakeDamage(Attack);
    }

    public bool BeAlive() => Health > 0;
}
