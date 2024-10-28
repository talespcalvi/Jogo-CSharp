using System;
// Classe decorator para Armadura encantada.
public class EnchantedArmorDecorator : WarriorDecorator
{
    public EnchantedArmorDecorator(Warrior warrior) : base(warrior)
    {
        Defense += 20;
    }

    public override void TakeDamage(int damage)
    {
        Console.WriteLine($"{Name} está protegido por uma armadura encantada!");
        base.TakeDamage(damage);
    }
}