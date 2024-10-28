using System;
// Classe decorator para Anel.
public class RingDecorator : WarriorDecorator
{
    private int reflexPower;

    public RingDecorator(Warrior warrior) : base(warrior)
    {
        reflexPower = 30; // 30% do dano será refletido.
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        ReflexDamage(damage);
    }

    private void ReflexDamage(int damage) // Método para refletir dano ao inimigo.
    {
        int reflexedDamage = (damage * reflexPower) / 100;
        Console.WriteLine($"{Name} reflete {reflexedDamage} de dano ao inimigo!");
    }

    public void CollectPowerEsphere() // Método para coletar uma esfera do poder que irá aumentar a porcentagem do dano refletido.
    {
        if (reflexPower < 100)
        {
            reflexPower += 10;
            Console.WriteLine($"{Name} coletou uma esfera de poder. O poder reflexivo agora é de {reflexPower}%");    
        }
    }

    public override bool BeAlive()
    {
        return warrior.BeAlive(); // Delegar a verificação para o guerreiro decorado.
    }

}
