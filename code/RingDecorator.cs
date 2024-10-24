using System;

public class RingDecorator : WarriorDecorator
{
    private int reflexPower;

    public RingDecorator(Warrior warrior) : base(warrior)
    {
        reflexPower = 10; //10%
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
