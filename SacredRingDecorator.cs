using System;
// Classe decorator para Anel Sagrado.
public class SacredRingDecorator : WarriorDecorator
{
    private int reflexPower;

    public SacredRingDecorator(Warrior warrior) : base(warrior)
    {
        reflexPower = 50; // 50% do dano será refletido.
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        ReflexDamage(damage);
    }

    private void ReflexDamage(int damage)
    {
        int reflexedDamage = (damage * reflexPower) / 100;
        Console.WriteLine($"{Name} reflete {reflexedDamage} de dano ao inimigo!");
    }

    public void CollectPowerEsphere()
    {
        if (reflexPower < 100)
        {
            reflexPower += 10;
            Console.WriteLine($"{Name} coletou uma esfera de poder. O poder reflexivo agora é de {reflexPower}%");    
        }
    }
}