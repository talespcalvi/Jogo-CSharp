using System;

public class ArmorDecorator : WarriorDecorator
{
    public ArmorDecorator(Warrior warrior) : base(warrior)
    {
        Defense += 10;
    }

    public override void TakeDamage(int damage)
    {
        Console.WriteLine($"{Name} está protegido por uma armadura!");
        base.TakeDamage(damage);
    }
}