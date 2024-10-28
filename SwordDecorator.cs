using System;
// Classe decorator para Espada.
public class SwordDecorator : WarriorDecorator
{
    public SwordDecorator(Warrior warrior) : base(warrior) 
    {
        Attack += 10; // Aumenta o dano base do warrior.
    }

    public override void ToAttack(Warrior target)
    {
        Console.WriteLine($"{Name} ataca com a espada!");
        base.ToAttack(target);
    }

    public override bool BeAlive()
    {
        return warrior.BeAlive(); // Delegar a verificação para o guerreiro decorado.
    }

}
