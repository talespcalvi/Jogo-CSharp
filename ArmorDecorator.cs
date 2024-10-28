using System;
// Classe decorator para Armadura.
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

    public override bool BeAlive()
    {
        return warrior.BeAlive(); // Delegar a verificação para o guerreiro decorado
    }

}
