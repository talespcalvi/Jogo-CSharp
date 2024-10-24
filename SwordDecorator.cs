using System;

public class SwordDecorator : WarriorDecorator
{
    public SwordDecorator(Warrior warrior) : base(warrior)
    {
        Attack += 10;
    }

    public override void ToAttack(Warrior target)
    {
        Console.WriteLine($"{Name} ataca com a espada!");
        base.ToAttack(target);
    }

    public override bool BeAlive()
    {
        return warrior.BeAlive(); // Delegar a verificação para o guerreiro decorado
    }

}
