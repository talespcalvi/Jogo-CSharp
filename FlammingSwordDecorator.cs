using System;
// Classe decorator para Espada Flamejante.
public class FlammingSwordDecorator : WarriorDecorator
{
    public FlammingSwordDecorator(Warrior warrior) : base(warrior)
    {
        Attack += 20;
    }

    public override void ToAttack(Warrior target)
    {
        Console.WriteLine($"{Name} ataca com a espada flamenjante!");
        base.ToAttack(target);
    }
}